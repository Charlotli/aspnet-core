using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;//
using Abp.Linq.Extensions;
using Abp.UI;
//
using Microsoft.EntityFrameworkCore;//
using MyProject.PhoneBooks.Dtos;//
using MyProject.PhoneBooks.Persons;

namespace MyProject.PhoneBooks
{
   public class PersonAppService: MyProjectAppServiceBase,IPersonAppService
   {

       /// <summary>
       /// 依赖注入；用依赖注入最大好处是 相当于一个人饿了我不知道吃什么东西，
       ///         但是我不知道冰箱里有什么东西，我想吃保证冰箱有就行了
       /// </summary>
       private readonly IRepository<Person> _personRepository;

       public PersonAppService(IRepository<Person> personRepository)
       {
           _personRepository = personRepository;
       }


       public Task CreateOrUpdatePersonAsync()
        {
            throw new NotImplementedException();
        }

       /// <summary>
       /// 修改添加
       /// </summary>
       /// <param name="input"></param>
       /// <returns></returns>
        public async Task CreateOrUpdatePersonAsync(CreateOrUpdatePersonlnput input)
        {
            if (input.PersonEditDto.Id.HasValue)//id有是修改 没有就是添加
            {
                await UpdatePersonAsync(input.PersonEditDto);
            }
            else
            {
                await CreatePersonAsync(input.PersonEditDto);
            }
            
        }

       /// <summary>
       /// 删除
       /// </summary>
       /// <param name="input"></param>
       /// <returns></returns>
        public async Task DeletePersonAsync(EntityDto input)
       {
           var entity = await _personRepository.GetAsync(input.Id);
            if (entity==null)
            {
                throw new UserFriendlyException("该数据已经不在数据库中，无法二次删除");
            }

           await _personRepository.DeleteAsync(input.Id);

       }

        public async Task<PagedResultDto<PersonListDto>> GePagedPersonAsync(GetPersonInput input)
        {

           var query= _personRepository.GetAll(); //返回的sql语句

            var personCount =await query.CountAsync(); //番薯查询调速

            var persons = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync(); //查询分页数据

            var dtos = persons.MapTo<List<PersonListDto>>();


            return new PagedResultDto<PersonListDto>(personCount, dtos);
        }

       

        public async Task<PersonListDto> GetPersonByIdAsync(NullableIdDto input)
        {

         var person=await _personRepository.GetAsync(input.Id.Value);
            return person.MapTo<PersonListDto>();
        }


       /// <summary>
       /// 修改
       /// </summary>
       /// <param name="input"></param>
       /// <returns></returns>
       protected async Task UpdatePersonAsync(PersonEditDto input)
       {
           var entity = await _personRepository.GetAsync(input.Id.Value);   
           await _personRepository.UpdateAsync(input.MapTo(entity));
       }

       /// <summary>
       /// 添加
       /// </summary>
       /// <param name="input"></param>
       /// <returns></returns>
       protected async Task CreatePersonAsync(PersonEditDto input)
       {
           _personRepository.Insert(input.MapTo<Person>());
       }
    }
}
