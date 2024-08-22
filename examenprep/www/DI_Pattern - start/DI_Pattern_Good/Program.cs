using DI_Pattern_Good;

Order order = new Order(new EmailSender());
order.ContactCustomer(1, "Your shipment will be delivered tomorrow at 4pm.");

Order order2 = new Order(new TelSender());
order2.ContactCustomer(1, "Your shipment will be delivered tomorrow at 4pm.");

Console.WriteLine("Press any key");
Console.ReadKey();