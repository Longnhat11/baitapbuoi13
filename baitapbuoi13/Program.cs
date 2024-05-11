// See https://aka.ms/new-console-template for more information
using baitapbuoi13;
using DataAccess.DTO;
using DataAccess.Libraryservices;
Console.OutputEncoding = System.Text.Encoding.UTF8;
var bookservices = new BookServices();
var authorservices = new AuthorServices();
var customerservices = new CustomerServices();
var ordersevices = new OrderServices();
int choice; string input;
Console.WriteLine("-------------------------------menu------------------------------------");
Console.WriteLine("1. Thêm , sửa ,xóa ,hiển thị ,tìm kiếm Thông tin sách");
Console.WriteLine("2.Thêm sửa xóa ,hiển thị , tìm kiếm thông tin tác giả ");
Console.WriteLine("3. thêm sửa xóa , hiển thị , tìm kiêm thông tin khach hàng");
Console.WriteLine("4.Thực hiện chức năng mua hàng ");
Console.WriteLine("5. Hiển thị danh sách đơn hàng , tìm kiếm và xem chi tiết đơn hàng ");
Console.WriteLine("------------------------------------------------------------------------");
Console.WriteLine("Nhập lựa chọn của bạn!");
input = Console.ReadLine();
if (checkInput.CheckNumber(input, out choice) == false
    || choice <= 0
    || choice > 5)
{ Console.WriteLine("Lựa chọn của bạn không hợp lệ!"); return; }
switch (choice)
{
    case 1:
        Console.WriteLine("chọn chức năng cần sử dụng:\n1.thêm sách\n2.sửa sách\n3.xóa sách\n4.hiển thị sách\n5.tìm kiếm sách theo tên sách");
        int chon; string select;
        select = Console.ReadLine();
        if (checkInput.CheckNumber(select,out chon)==false
            ||chon<=0
            ||chon>5){ Console.WriteLine("Lựa chọn của bạn không hợp lệ!"); return; }
        Book book = new Book();
        switch (chon)
        {
            case 1:
                Console.WriteLine("nhập sách cần thêm:");
                Console.WriteLine("nhap BookID");
                int bookid; string InputBook; bool Check;
                do
                {
                    InputBook = Console.ReadLine();
                    if (checkInput.CheckNumber(InputBook, out bookid) == true)
                    {
                        book.BookID = bookid;
                        Check = true;
                    }
                    else { Check = false; }
                } while (!Check);
                Console.WriteLine("nhap ten sach:");
                do
                {
                    InputBook = Console.ReadLine();
                    if(checkInput.ContainsNumber(InputBook)==true
                        ||checkInput.CheckContainSpecialChar(InputBook)==true
                        ||checkInput.CheckIsNullOrWhiteSpace(InputBook)==true)
                    {Check = false;}
                    else { 
                        book.BookName = InputBook;
                        Check = true;
                    }
                }while(!Check);
                Console.WriteLine("nhap ID tac gia");
                int authorid;
                do
                {
                    InputBook = Console.ReadLine();
                    if (checkInput.CheckNumber(InputBook, out authorid) == true)
                    {
                        book.AuthorID=authorid;
                        Check = true;
                    }
                    else { Check = false; }
                } while (!Check);
                Console.WriteLine("nhap ID danh muc");
                int categoryID;
                do
                {
                    InputBook = Console.ReadLine();
                    if (checkInput.CheckNumber(InputBook, out categoryID) == true)
                    {
                        book.CategoryID = categoryID;
                        Check = true;
                    }
                    else { Check = false; }
                } while (!Check);
                Console.WriteLine("nhap gia tien:");
                decimal price;
                do
                {
                    InputBook = Console.ReadLine();
                    if (checkInput.CheckNumberDecima(InputBook, out price) == true)
                    {
                        book.Price= price;
                        Check = true;
                    }
                    else { Check = false; }
                } while (!Check);
                Console.WriteLine("nhap so luong sach:");
                int stock;
                do
                {
                    InputBook = Console.ReadLine();
                    if (checkInput.CheckNumber(InputBook, out stock) == true)
                    {
                        book.Stock=stock;
                        Check = true;
                    }
                    else { Check = false; }
                } while (!Check);
                bookservices.AddBook(book);
                break;
            case 2:
                Console.WriteLine("nhập sách cần Update: ");
                Console.WriteLine("nhap BookID");
                int bookidUpdate; string InputBookUpdate; bool CheckCase2;
                do
                {
                    InputBookUpdate = Console.ReadLine();
                    if (checkInput.CheckNumber(InputBookUpdate, out bookidUpdate) == true)
                    {
                        book.BookID = bookidUpdate;
                        CheckCase2 = true;
                    }
                    else { CheckCase2 = false; }
                } while (!CheckCase2);
                Console.WriteLine("nhap ten sach:");
                do
                {
                    InputBookUpdate = Console.ReadLine();
                    if (checkInput.ContainsNumber(InputBookUpdate) == true
                        || checkInput.CheckContainSpecialChar(InputBookUpdate) == true
                        || checkInput.CheckIsNullOrWhiteSpace(InputBookUpdate) == true)
                    { CheckCase2 = false; }
                    else
                    {
                        book.BookName = InputBookUpdate;
                        CheckCase2 = true;
                    }
                } while (!CheckCase2);
                Console.WriteLine("nhap ID tac gia");
                int authoridUpdate;
                do
                {
                    InputBookUpdate = Console.ReadLine();
                    if (checkInput.CheckNumber(InputBookUpdate, out authoridUpdate) == true)
                    {
                        book.AuthorID = authoridUpdate;
                        CheckCase2 = true;
                    }
                    else { CheckCase2 = false; }
                } while (!CheckCase2);
                Console.WriteLine("nhap ID danh muc");
                int categoryIDUpdate;
                do
                {
                    InputBookUpdate = Console.ReadLine();
                    if (checkInput.CheckNumber(InputBookUpdate, out categoryIDUpdate) == true)
                    {
                        book.CategoryID = categoryIDUpdate;
                        CheckCase2 = true;
                    }
                    else { CheckCase2 = false; }
                } while (!CheckCase2);
                Console.WriteLine("nhap gia tien:");
                decimal priceUpdate;
                do
                {
                    InputBookUpdate = Console.ReadLine();
                    if (checkInput.CheckNumberDecima(InputBookUpdate, out priceUpdate) == true)
                    {
                        book.Price = priceUpdate;
                        CheckCase2 = true;
                    }
                    else { CheckCase2 = false; }
                } while (!CheckCase2);
                Console.WriteLine("nhap so luong sach:");
                int stockUpdate;
                do
                {
                    InputBookUpdate = Console.ReadLine();
                    if (checkInput.CheckNumber(InputBookUpdate, out stockUpdate) == true)
                    {
                        book.Stock = stockUpdate;
                        CheckCase2 = true;
                    }
                    else { CheckCase2 = false; }
                } while (!CheckCase2);
                bookservices.UpdateBook(book);
                break;
            case 3:
                Console.WriteLine("nhap Id sach can xoa:");
                do
                {
                    InputBook = Console.ReadLine();
                    if (checkInput.CheckNumber(InputBook, out bookid) == true)
                    {Check = true; }
                    else { Check = false; }
                } while (!Check);
                bookservices.DeleteBook(bookid);
                break;
            case 4:
                Console.WriteLine("nhập Id sách cần hiển thị:");
                do
                {
                    InputBook = Console.ReadLine();
                    if (checkInput.CheckNumber(InputBook, out bookid) == true)
                    { Check = true; }
                    else { Check = false; }
                } while (!Check);
                book = bookservices.GetBooks(bookid);
                if(book == null) { Console.WriteLine("không có sách có Id"+bookid); }
                else
                {
                    Console.WriteLine("BookId "+book.BookID);
                    Console.WriteLine("BookName " + book.BookName);
                    Console.WriteLine("CategoryId " + book.CategoryID);
                    Console.WriteLine("AuthorId " + book.AuthorID);
                    Console.WriteLine("Price " + book.Price);
                    Console.WriteLine("Stock " + book.Stock);
                }
                break;
            case 5:  
                Console.WriteLine("nhập tên sách tìm kiếm:");
                do
                {
                    InputBook = Console.ReadLine();
                    if (checkInput.ContainsNumber(InputBook) == true
                        || checkInput.CheckContainSpecialChar(InputBook) == true
                        || checkInput.CheckIsNullOrWhiteSpace(InputBook) == true)
                    { Check = false; }
                    else
                    {Check = true;}
                } while (!Check);
                List<Book> books = bookservices.SearchBooks(InputBook);
                foreach (var item in books)
                {
                    Console.WriteLine("BookId " + item.BookID);
                    Console.WriteLine("BookName " + book.BookName);
                    Console.WriteLine("CategoryId " + book.CategoryID);
                    Console.WriteLine("AuthorId " + book.AuthorID);
                    Console.WriteLine("Price " + book.Price);
                    Console.WriteLine("Stock " + book.Stock);
                }
                break;
            default:
                break;
        }
        break;
    case 2:
        Console.WriteLine("chọn chức năng cần sử dụng:\n1.thêm tác giả\n2.sửa thông tin tác giả\n3.xóa tác giả\n4.hiển thị thông tin tác giả\n5.tìm kiếm tác giả theo từ khóa");
        select = Console.ReadLine();
        if (checkInput.CheckNumber(select, out chon) == false
            || chon <= 0
            || chon > 5) { Console.WriteLine("Lựa chọn của bạn không hợp lệ!"); return; }
        Authors author = new Authors();
        switch (chon)
        {
            case 1:
                Console.WriteLine("nhập tác giả cần thêm:");
                Console.WriteLine("nhap AuthorID");
                int AuthorId; string InputAuthor; bool Check;
                do
                {
                    InputAuthor = Console.ReadLine();
                    if (checkInput.CheckNumber(InputAuthor, out AuthorId) == true)
                    {
                        author.AuthorId = AuthorId;
                        Check = true;
                    }
                    else { Check = false; }
                } while (!Check);
                Console.WriteLine("nhập tên tác giả:");
                do
                {
                    InputAuthor = Console.ReadLine();
                    if (checkInput.ContainsNumber(InputAuthor) == true
                        || checkInput.CheckContainSpecialChar(InputAuthor) == true
                        || checkInput.CheckIsNullOrWhiteSpace(InputAuthor) == true)
                    { Check = false; }
                    else
                    {
                        author.AuthorName = InputAuthor;
                        Check = true;
                    }
                } while (!Check);
                Console.WriteLine("nhập Quốc gia tác giả:");
                do
                {
                    InputAuthor = Console.ReadLine();
                    if (checkInput.ContainsNumber(InputAuthor) == true
                        || checkInput.CheckContainSpecialChar(InputAuthor) == true
                        || checkInput.CheckIsNullOrWhiteSpace(InputAuthor) == true)
                    { Check = false; }
                    else
                    {
                        author.Country=InputAuthor;
                        Check = true;
                    }
                } while (!Check);
                authorservices.AddAuthor(author);
                break;
            case 2:
                Console.WriteLine("nhập tác giả cần Update: ");
                Console.WriteLine("nhap AuthorID");
                do
                {
                    InputAuthor = Console.ReadLine();
                    if (checkInput.CheckNumber(InputAuthor, out AuthorId) == true)
                    {
                        author.AuthorId = AuthorId;
                        Check = true;
                    }
                    else { Check = false; }
                } while (!Check);
                Console.WriteLine("nhập tên tác giả:");
                do
                {
                    InputAuthor = Console.ReadLine();
                    if (checkInput.ContainsNumber(InputAuthor) == true
                        || checkInput.CheckContainSpecialChar(InputAuthor) == true
                        || checkInput.CheckIsNullOrWhiteSpace(InputAuthor) == true)
                    { Check = false; }
                    else
                    {
                        author.AuthorName = InputAuthor;
                        Check = true;
                    }
                } while (!Check);
                Console.WriteLine("nhập Quốc gia tác giả:");
                do
                {
                    InputAuthor = Console.ReadLine();
                    if (checkInput.ContainsNumber(InputAuthor) == true
                        || checkInput.CheckContainSpecialChar(InputAuthor) == true
                        || checkInput.CheckIsNullOrWhiteSpace(InputAuthor) == true)
                    { Check = false; }
                    else
                    {
                        author.Country = InputAuthor;
                        Check = true;
                    }
                } while (!Check);
                authorservices.UpdateAuthor(author);
                break;
            case 3:
                Console.WriteLine("nhap Id tác giả can xoa:");
                do
                {
                    InputAuthor = Console.ReadLine();
                    if (checkInput.CheckNumber(InputAuthor, out AuthorId) == true)
                    { Check = true; }
                    else { Check = false; }
                } while (!Check);
                authorservices.DeleteAuthor(AuthorId);
                break;
            case 4:
                Console.WriteLine("nhập Id tác giả cần hiển thị:");
                do
                {
                    InputAuthor = Console.ReadLine();
                    if (checkInput.CheckNumber(InputAuthor, out AuthorId) == true)
                    { Check = true; }
                    else { Check = false; }
                } while (!Check);
                author= authorservices.GetAuthor(AuthorId);
                if (author == null) { Console.WriteLine("không có tác giả có Id" + AuthorId); }
                else
                {
                    Console.WriteLine("AuthorId " + author.AuthorId);
                    Console.WriteLine("AuthorName " + author.AuthorName);
                    Console.WriteLine("Country " + author.Country);
                }
                break;
            case 5:
                Console.WriteLine("nhập từ khóa tìm kiếm:");
                do
                {
                    InputAuthor = Console.ReadLine();
                    if (checkInput.ContainsNumber(InputAuthor) == true
                        || checkInput.CheckContainSpecialChar(InputAuthor) == true
                        || checkInput.CheckIsNullOrWhiteSpace(InputAuthor) == true)
                    { Check = false; }
                    else
                    { Check = true; }
                } while (!Check);
                List<Authors> authors = authorservices.SearchAuthors(InputAuthor);
                foreach (var item in authors)
                {
                    Console.WriteLine("AuthorId " + item.AuthorId);
                    Console.WriteLine("AuthorName " +item.AuthorName);
                    Console.WriteLine("Country " + item.Country);
                }
                break;
            default:
                break;
        }
        break;
    case 3:
        Console.WriteLine("chọn chức năng cần sử dụng:\n1.thêm khách hàng\n2.sửa thông tin khách hàng\n3.xóa khách hàng\n4.hiển thị thông tin khách hàng\n5.tìm kiếm khách hàng theo từ khóa");
        select = Console.ReadLine();
        if (checkInput.CheckNumber(select, out chon) == false
            || chon <= 0
            || chon > 5) { Console.WriteLine("Lựa chọn của bạn không hợp lệ!"); return; }
        customer Customer = new customer();
        switch (chon)
        {
            case 1:
                Console.WriteLine("nhập khách hàng cần thêm:");
                Console.WriteLine("nhap CustomerID");
                int CustomerId; string InputCustomer; bool Check;
                do
                {
                    InputCustomer = Console.ReadLine();
                    if (checkInput.CheckNumber(InputCustomer, out CustomerId) == true)
                    {
                        Customer.customerID = CustomerId;
                        Check = true;
                    }
                    else { Check = false; }
                } while (!Check);
                Console.WriteLine("nhập tên khách hàng:");
                do
                {
                    InputCustomer = Console.ReadLine();
                    if (checkInput.ContainsNumber(InputCustomer) == true
                        || checkInput.CheckIsNullOrWhiteSpace(InputCustomer) == true)
                    { Check = false; }
                    else
                    {
                        Customer.customerName = InputCustomer;
                        Check = true;
                    }
                } while (!Check);
                Console.WriteLine("nhập địa chỉ khách hàng:");
                do
                {
                    InputCustomer = Console.ReadLine();
                    if (checkInput.ContainsNumber(InputCustomer) == true
                        || checkInput.CheckIsNullOrWhiteSpace(InputCustomer) == true)
                    { Check = false; }
                    else
                    {
                        Customer.customeraddrress = InputCustomer;
                        Check = true;
                    }
                } while (!Check);
                customerservices.AddCustomer(Customer);
                break;
            case 2:
                Console.WriteLine("nhập khách hàng cần Update: ");
                Console.WriteLine("nhap CustomerID");
                do
                {
                    InputCustomer = Console.ReadLine();
                    if (checkInput.CheckNumber(InputCustomer, out CustomerId) == true)
                    {
                        Customer.customerID = CustomerId;
                        Check = true;
                    }
                    else { Check = false; }
                } while (!Check);
                Console.WriteLine("nhập tên khách hàng:");
                do
                {
                    InputCustomer = Console.ReadLine();
                    if (checkInput.ContainsNumber(InputCustomer) == true
                        || checkInput.CheckIsNullOrWhiteSpace(InputCustomer) == true)
                    { Check = false; }
                    else
                    {
                        Customer.customerName = InputCustomer;
                        Check = true;
                    }
                } while (!Check);
                Console.WriteLine("nhập địa chỉ khách hàng:");
                do
                {
                    InputCustomer = Console.ReadLine();
                    if (checkInput.ContainsNumber(InputCustomer) == true
                        || checkInput.CheckIsNullOrWhiteSpace(InputCustomer) == true)
                    { Check = false; }
                    else
                    {
                        Customer.customeraddrress = InputCustomer;
                        Check = true;
                    }
                } while (!Check);
                customerservices.UpdateCustomer(Customer);
                break;
            case 3:
                Console.WriteLine("nhap Id khách hàng can xoa:");
                do
                {
                    InputCustomer = Console.ReadLine();
                    if (checkInput.CheckNumber(InputCustomer, out CustomerId) == true)
                    { Check = true; }
                    else { Check = false; }
                } while (!Check);
                customerservices.DeleteCustomer(CustomerId);
                break;
            case 4:
                Console.WriteLine("nhập Id Khách hàng cần hiển thị:");
                do
                {
                    InputCustomer = Console.ReadLine();
                    if (checkInput.CheckNumber(InputCustomer, out CustomerId) == true)
                    { Check = true; }
                    else { Check = false; }
                } while (!Check);
                Customer=customerservices.GetCustomer(CustomerId);
                if (Customer == null) { Console.WriteLine("không có khách hàng có Id" + CustomerId); }
                else
                {
                    Console.WriteLine("CustomerId " + Customer.customerID);
                    Console.WriteLine("CustomerName " + Customer.customerName);
                    Console.WriteLine("customeraddrress " + Customer.customeraddrress);
                }
                break;
            case 5:
                Console.WriteLine("nhập từ khóa tìm kiếm:");
                do
                {
                    InputCustomer = Console.ReadLine();
                    if (checkInput.ContainsNumber(InputCustomer) == true
                        || checkInput.CheckIsNullOrWhiteSpace(InputCustomer) == true)
                    { Check = false; }
                    else
                    { Check = true; }
                } while (!Check);
                List<customer>customers=customerservices.SearchCustomers(InputCustomer);
                foreach (var item in customers)
                {
                    Console.WriteLine("CustomerId " + item.customerID);
                    Console.WriteLine("CustomerName " + item.customerName);
                    Console.WriteLine("customeraddrress " + item.customeraddrress);
                }
                break;
            default:
                break;
        }
        break;
    case 4:
        Orders order = new Orders(); string InputOder;bool check;int ID;DateTime dateTimeOder;
        Console.WriteLine("Bắt đầu mua hàng");
        Console.WriteLine("Nhập OderID");
        do
        {
            InputOder = Console.ReadLine();
            if (checkInput.CheckNumber(InputOder, out ID) == true)
            {
                order.OrderID = ID;
                check = true;
            }
            else { check = false; }
        } while (!check);
        Console.WriteLine("Nhập Ngày mua hàng");
        do
        {
            InputOder= Console.ReadLine();
            if (checkInput.CheckDateTime(InputOder)==true)
            {
                dateTimeOder = DateTime.Parse(InputOder);
                order.OrderDate = dateTimeOder;
                check=true;
            }
            else { check = false; }
        }while (!check);
        Console.WriteLine("Nhập ID khách hàng");
        do
        {
            InputOder = Console.ReadLine();
            if (checkInput.CheckNumber(InputOder, out ID) == true)
            {
                order.CustomerID = ID;
                check = true;
            }
            else { check = false; }
        } while (!check);
        Console.WriteLine("Nhập Tổng tiền");
        decimal TotalAmount;
        do
        {
            InputOder = Console.ReadLine();
            if (checkInput.CheckNumberDecima(InputOder, out TotalAmount) == true)
            {
                order.TotalAmount = TotalAmount;
                check = true;
            }
            else { check = false; }
        } while (!check);
        ordersevices.PlaceOrder(order);
        break;
    case 5:
        Console.WriteLine("1. Hiển thị danh sách đơn hàng\n2.Tìm kiếm và xem chi tiết đơn hàng");
        select = Console.ReadLine();
        if (checkInput.CheckNumber(select, out chon) == false
            || chon <= 0
            || chon > 2) { Console.WriteLine("Lựa chọn của bạn không hợp lệ!"); return; }
        Orders orders = new Orders();
        List<Orders> listorders = new List<Orders>();
        switch (chon)
        {
            case 1:
                Console.WriteLine("danh sách đơn hàng!");
                listorders = ordersevices.GetAllOrders();
                foreach (var item in listorders)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("Oderid: {0} ", item.OrderID);
                    Console.WriteLine("Customerid: {0} ", item.CustomerID);
                    Console.WriteLine("OderDate: {0} ", item.OrderDate.ToString("dd/MM/yyyy"));
                    Console.WriteLine("TotalAmount: {0} ", item.TotalAmount);
                }
                break;
            case 2:
                Console.WriteLine("Nhập OderId cần xem chi tiêt!");
                string InputorderId;int orderid;bool checkId;
                do
                {
                    InputorderId = Console.ReadLine();
                    if(checkInput.CheckNumber(InputorderId,out orderid)==true)
                    {
                        checkId= true;
                    }
                    else {checkId= false; }
                } while (!checkId);
                ordersevices.GetOrderdetails(orderid);
                break;
            default:
                break;
        }
        break;
    default:
        break;
}


