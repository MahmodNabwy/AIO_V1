﻿using AIO.Contracts.Interfaces.Custom;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.Features.Projects.Commands
{
    public class ProjectUpdateCommand : IRequest<IHolderOfDTO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractNumber { get; set; } //رقم العقد
        public string PoNumber { get; set; } // رقم امر الشراء
        public string AssignedNumber { get; set; } // رقم الاسناد
        public DateTime AssignedToDate { get; set; } // تاريخ الاسناد
        public DateTime PrimaryRecieptDate { get; set; } // تاريخ الاستلام الابتدائي
        public DateTime FinalRecieptDate { get; set; } // تاريخ الاستلام النهائي
        public decimal TotalPrice { get; set; } // قيمة العقد
        public int currency { get; set; } // نوع عملة قيمة العقد
        public decimal LimitOfLiability { get; set; }
        public int? ProjectProfitabilityRatio { get; set; } // نسبة ربحية المشروع
        public int ImplementationPeriod { get; set; }//فترة التنفيذ
        public int InsurancePeriod { get; set; }//فترة الضمان
        public string PaymentCondition { get; set; } // شروط الدفع
        public bool IsNew { get; set; } // اعمال مستجدة او مشروع جديد
        public int? ParentId { get; set; } // Refer tp project id when is New = true (اعمال مستجدة)
        public int ProjectTypeId { get; set; } // نوع المشروع
        public int OwnerId { get; set; } // الجهة المالكة                                 
        public bool? HasDiscount { get; set; } = false; //خصم خاص
        public decimal? TotalPriceAfterDiscount { get; set; } // إجمالي قيمة العقد بعد الخصم
        public bool IsConfirmed { get; set; } = false;
        //public bool IncludeTaxes { get; set; } = false;
    }
}
