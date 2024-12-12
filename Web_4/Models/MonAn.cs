﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web_4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class MonAn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MonAn()
        {
            this.HoaDonDatMons = new HashSet<HoaDonDatMon>();
        }

        [Key]    
        public int MaMon { get; set; }

        [DisplayName("Tên món")]
        [Required(ErrorMessage = "Phải có {0}")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "{0} có độ dài từ {2} đến {1} ký tự")]
        public string TenMon { get; set; }

        [DisplayName("Loại món")]
        [Required(ErrorMessage = "Phải có {0}")]
        [StringLength(30, ErrorMessage = "{0} có độ dài {1} ký tự")]
        public string LoaiMon { get; set; }

        [DisplayName("Đơn giá")]
        [Required(ErrorMessage = "Phải có {0}")]
        [Range(0, int.MaxValue, ErrorMessage = "{0} phải lớn hơn {1}")]
        public Nullable<decimal> DonGia { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonDatMon> HoaDonDatMons { get; set; }
    }
}