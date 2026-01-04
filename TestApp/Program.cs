// See https://aka.ms/new-console-template for more information
////SendNotification(Email);

////SendNotification(SMS);

//Notification n = Email;
//n += SMS;

////n();
////SendNotification(n);


//Action a = () => Console.Write("action");
////a();
//SendNotificationA(a);


//void Email()
//{
//    Console.WriteLine("email");
//}

//void SMS()
//{
//    Console.WriteLine("sms");
//}


//void SendNotification(Notification p)
//{
//    p.Invoke();
//}
//void SendNotificationA(Action a)
//{
//    a.Invoke();
//}
//public delegate void Notification();


//Publisher p = new Publisher();
//p.Notification += (string m) => Console.Write(m);

//p.Notify("hello");

//public delegate void NotificationEventHandler(string message);

//public class Publisher
//{
//    public event NotificationEventHandler Notification;



//    public void Notify(string message)
//    {
//        Notification?.Invoke(message);
//    }
//}





//var orders = new List<Order>
//{
//    new() { CustomerId = 1, Total = 100 },
//    new() { CustomerId = 1, Total = 50 },
//    new() { CustomerId = 2, Total = 75 }
//};

//var grp = orders.GroupBy(o => o.CustomerId).ToList();

//var totalByCustomer = orders
//    .GroupBy(o => o.CustomerId)
//    .Select(g => new
//    {
//        CustomerId = g.Key,
//        TotalSpent = g.Sum(o => o.Total),
//        OrdersCount = g.Count()
//    })
//    .ToList();


//public class Order
//{
//    public int CustomerId { get; set; }
//    public decimal Total { get; set; }
//};

var users = new List<AppUser>
{
    new() { Id = 1, Name = "Alice" },
    new() { Id = 2, Name = "Bob" }
};

var roles = new List<UserRole>
{
    new() { UserId = 1, RoleName = "Admin" },
    new() { UserId = 1, RoleName = "Moderator" },
    new() { UserId = 2, RoleName = "User" },
     new() { UserId = 2, RoleName = "Admin" }
};




//join
var userrole = users.Join(roles, u => u.Id, r => r.UserId, 
    (u, r) => new
    {
        UserId = u.Id,
        name = u.Name,
        roleName = r.RoleName,
    }
).ToList();

//groupby
var grpByAdmin = userrole.GroupBy(x => x.roleName).Select(u => new
{
    RoleName = u.Key,
    TotalRoles = u.Count(),
    Roles = u.Select(o => o.name).ToList()
}).ToList();


//any
var isadmin = grpByAdmin.Any(x=>x.RoleName.Equals("admin", StringComparison.OrdinalIgnoreCase));


//all
var admin = grpByAdmin.All(x => x.RoleName.Equals("admin", StringComparison.OrdinalIgnoreCase));

var s = "";


public class AppUser
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class UserRole
{
    public int UserId { get; set; }
    public string RoleName { get; set; }
}



