using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Castle.MicroKernel;
using MyProject.PhoneBooks.Persons;

namespace MyProject.PhoneBooks.PhoneNumbers
{
    /// <summary>
    /// 电话号码
    /// </summary>
   public class PhoneNumber:Entity<long>,IHasCreationTime
    {
        /// <summary>
        /// 电话号码
        /// </summary>
        [Required]
        [MaxLength(11)]
        public string Number { get; set; }

        /// <summary>
        /// 电话类型
        /// </summary>
        public PhoneNumber Type { get; set; }


        public int PersonId { get; set; }

        public Person  Person { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public DateTime CreationTime { get; set; }

    }
}
