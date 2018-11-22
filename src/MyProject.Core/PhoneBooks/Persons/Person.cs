using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace MyProject.PhoneBooks.Persons
{
    /// <summary>
    /// 人员
    /// </summary>
    
    public class Person :FullAuditedEntity //可以实现好多状态比如删除创建时间等等，不用担心状态
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [EmailAddress]
        [MaxLength(80)]
        public string EmailAddress { get; set; }

        /// <summary>
        /// 地址信息 
        /// </summary>
        [MaxLength(200)]
        public string Address { get; set; }



    }
}
