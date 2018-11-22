using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using MyProject.Dto;

namespace MyProject.PhoneBooks.Dtos
{
    /// <summary>
    /// 分页查询
    /// </summary>
    public class GetPersonInput : PagedAndSortedInputDto, IShouldNormalize
    {
        //好的项目分为
        //(abp;IApplicationService:相当于)ViewModel=>Dto =>model

        public string FilterText { get; set; }


        public void Normalize()
        {
            //同id排序
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
                 
            }
        }
    }
}
