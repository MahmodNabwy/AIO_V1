using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Contracts.Enums
{
    public enum PaymentMethodTypes
    {
        PaymentDown=1,//دفعة مقدمة
        SupplyBatch =2,// دفعة توريد
        InstallationBatch=3,//دفعة تركيب
        SupplyAndInstallationBatch=4 //دفعة تركيب وتوريد

    }
}
