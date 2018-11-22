using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyProject.PhoneBooks.Persons;

namespace MyProject.PhoneBooks.Dtos
{
    [AutoMapFrom(typeof(Person))] //映射到bpo页面
   public class PersonListDto:FullAuditedEntityDto
    {
        /// <summary>
        /// 姓名
        /// </summary>
       
        public string Name { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        
        public string EmailAddress { get; set; }

        /// <summary>
        /// 地址信息 
        /// </summary>
        
        public string Address { get; set; }

    }
}
