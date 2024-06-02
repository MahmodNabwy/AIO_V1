using AIO.Contracts.DTOs.Setter.ProjectSupplier;
using AIO.Contracts.DTOs.Setter.SupplierProjectInsurances;
using AIO.Contracts.DTOs.Setter.SupplierProjectPaymentMethods;
using AIO.Contracts.Enums;
using AIO.Contracts.Interfaces.Custom;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.Features.ProjectsSuppliers.Commands
{
    public class ProjectSupplierAddCommand : IRequest<IHolderOfDTO>
    {

        public ProjectSupplierDataSetterDTO projectSupplierDataSetterDTO { get; set; }
        public List<SupplierProjectInsurancesSetterDTO> InsuranceConditions { get; set; }
        public List<SupplierProjectSupplierPaymentMethodSetterDTO> PaymentMethods { get; set; }
        public List<int> TaxesIds { get; set; }
        

    }


}
