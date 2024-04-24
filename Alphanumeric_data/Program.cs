int invoiceNumber = 1201;
decimal productShares = 25.4568m;
decimal subtotal = 2750.00m;
decimal taxPercentage = .15825m;
decimal total = 3185.19m;

Console.WriteLine($"Invoice Number: {invoiceNumber}\n\tShares: {productShares:N3} Product\n\tSub Total: {subtotal:C}\n\t\tTax: {taxPercentage:P2}\n\tTotal Billed: {total:C}");



