﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.ViewModels
{
    public class ClientLoginViewModel
    {
        [Required]
        [StringLength(10, ErrorMessage = "{0}必須小於{1}字")]
        [DisplayName("名")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "{0}必須小於{1}字")]
        [DataType(DataType.Password)]
        [DisplayName("中間名")]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "{0}必須小於{1}字")]
        [DisplayName("姓")]
        public string LastName { get; set; }
        [DisplayName("生日")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DateOfBirth { get; set; }
    }
}