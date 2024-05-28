﻿using AIO.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.DTOs.Setter.ProjectSupplier
{
    public class ProjectSupplierDataSetterDTO
    {
        public int SupplierId { get; set; }
        public int ProjectId { get; set; }
        public int TaxId { get; set; }
        public string ContractNumber { get; set; }
        public DateTime PrimaryRecieptDate { get; set; }
        public DateTime FinalRecieptDate { get; set; }
        public decimal TotalPrice { get; set; }
        public Concurrency_type TotalPriceConcurrency { get; set; }
        public int ImplementationPeriod { get; set; }
        public int InsurancePeriod { get; set; }
        public string PaymentCondition { get; set; }
    }
}