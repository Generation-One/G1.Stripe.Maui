using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1.Stripe.Maui;
public interface IPaymentSheet
{
    void Initialize(string publishableKey);
    Task<PaymentSheetResult> Open(PaymentSheetOptions options);
}
