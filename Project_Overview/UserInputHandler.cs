public class UserInputHandler
{
    private readonly LibraryService _libraryService;

    public UserInputHandler(LibraryService libraryService)
    {
        _libraryService = libraryService ?? throw new ArgumentNullException(nameof(libraryService));
    }

    public void ShowMenu()
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            Console.Clear(); // Xóa màn hình
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║             Hệ Thống quản lý Thư viện      ║");
            Console.WriteLine("╠════════════════════════════════════════════╣");
            Console.WriteLine("║ 1. Thêm Sách                               ║");
            Console.WriteLine("║ 2. Thêm Thành Viên                         ║");
            Console.WriteLine("║ 3. Ngày Mượn Sách                          ║");
            Console.WriteLine("║ 4. Ngày Trả Sách                           ║");
            Console.WriteLine("║ 5. Danh Sách các Sách có sẵn               ║");
            Console.WriteLine("║ 6. Danh Sách các Thành viên                ║");
            Console.WriteLine("║ 7. Danh Sách tất cả Giao dịch              ║");
            Console.WriteLine("║ 8. Xóa Sách                                ║");
            Console.WriteLine("║ 9. Xóa Thành Viên                          ║");
            Console.WriteLine("║ 10. Xóa Giao dịch                          ║");
            Console.WriteLine("║ 11. Thoát                                  ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.Write("Lựa chọn của bạn: ");
            string option = Console.ReadLine()!;

            switch (option)
            {
                case "1":
                    HandleAddBook();
                    break;

                case "2":
                    HandleAddMember();
                    break;

                case "3":
                    HandleBorrowBook();
                    break;

                case "4":
                    HandleReturnBook();
                    break;

                case "5":
                    ListAvailableBooks();
                    break;

                case "6":
                    ListAllMembers();
                    break;

                case "7":
                    ListAllTransactions();
                    break;

                case "8":
                    HandleDeleteBook();
                    break;

                case "9":
                    HandleDeleteMember();
                    break;

                case "10":
                    HandleDeleteTransaction();
                    break;

                case "11":
                    keepRunning = false;
                    break;

                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Nhập lại.");
                    break;
            }

            if (keepRunning)
            {
                Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                Console.ReadKey();
            }
        }
    }

    private void HandleAddBook()
    {
        Console.Clear();
        Console.WriteLine("╔════════════════════════════════════════════╗");
        Console.WriteLine("║                 Thêm Sách                  ║");
        Console.WriteLine("╚════════════════════════════════════════════╝");

        Console.Write("Nhập tiêu đề Sách: ");
        string bookTitle = Console.ReadLine()!;
        Console.Write("Nhập tên Tác giả: ");
        string bookAuthor = Console.ReadLine()!;

        Console.Clear();
        Console.WriteLine("╔════════════════════════════════════════════╗");
        Console.WriteLine("║                 Xác Nhận                   ║");
        Console.WriteLine("╠════════════════════════════════════════════╣");
        Console.WriteLine("║ 1. Lưu                                     ║");
        Console.WriteLine("║ 2. Hủy                                     ║");
        Console.WriteLine("╚════════════════════════════════════════════╝");
        Console.Write("Lựa chọn của bạn: ");
        string saveOption = Console.ReadLine()!;

        if (saveOption == "1")
        {
            _libraryService.AddBook(bookTitle, bookAuthor);
            Console.WriteLine("Thêm Sách thành công.");
        }
        else
        {
            Console.WriteLine("Hủy bỏ thao tác.");
        }
    }

    private void HandleAddMember()
    {
        Console.Clear();
        Console.WriteLine("╔════════════════════════════════════════════╗");
        Console.WriteLine("║              Thêm Thành Viên               ║");
        Console.WriteLine("╚════════════════════════════════════════════╝");

        Console.Write("Nhập tên Thành viên: ");
        string memberName = Console.ReadLine()!;

        Console.Clear();
        Console.WriteLine("╔════════════════════════════════════════════╗");
        Console.WriteLine("║                 Xác Nhận                   ║");
        Console.WriteLine("╠════════════════════════════════════════════╣");
        Console.WriteLine("║ 1. Lưu                                     ║");
        Console.WriteLine("║ 2. Hủy                                     ║");
        Console.WriteLine("╚════════════════════════════════════════════╝");
        Console.Write("Lựa chọn của bạn: ");
        string saveOption = Console.ReadLine()!;

        if (saveOption == "1")
        {
            _libraryService.AddMember(memberName);
            Console.WriteLine("Thêm Thành viên thành công.");
        }
        else
        {
            Console.WriteLine("Hủy bỏ thao tác.");
        }
    }

    private void HandleBorrowBook()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║              Ngày Mượn Sách                ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");

            Console.Write("Nhập Id Sách cần mượn: ");
            if (!Guid.TryParse(Console.ReadLine(), out Guid bookIdToBorrow))
            {
                Console.WriteLine("Id Sách không đúng. Bạn có muốn nhập lại?");
                Console.WriteLine("1. Đồng ý");
                Console.WriteLine("2. Hủy");
                Console.Write("Lựa chọn của bạn: ");
                string retryOption = Console.ReadLine()!;

                if (retryOption == "1")
                {
                    continue;
                }
                else
                {
                    return;
                }
            }

            Console.Write("Nhập Id Thành viên: ");
            if (!Guid.TryParse(Console.ReadLine(), out Guid memberIdToBorrow))
            {
                Console.WriteLine("Id Thành viên không đúng. Bạn có muốn nhập lại?");
                Console.WriteLine("1. Đồng ý");
                Console.WriteLine("2. Hủy");
                Console.Write("Lựa chọn của bạn: ");
                string retryOption = Console.ReadLine()!;

                if (retryOption == "1")
                {
                    continue;
                }
                else
                {
                    return;
                }
            }

            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║                 Xác Nhận                   ║");
            Console.WriteLine("╠════════════════════════════════════════════╣");
            Console.WriteLine("║ 1. Lưu                                     ║");
            Console.WriteLine("║ 2. Hủy                                     ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.Write("Lựa chọn của bạn: ");
            string saveOption = Console.ReadLine()!;

            if (saveOption == "1")
            {
                _libraryService.BorrowBook(bookIdToBorrow, memberIdToBorrow);
                Console.WriteLine("Mượn Sách thành công.");
            }
            else
            {
                Console.WriteLine("Hủy bỏ thao tác.");
            }
            return;
        }
    }

    private void HandleReturnBook()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║                Ngày Trả Sách               ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");

            Console.Write("Nhập Id Sách cần trả: ");
            if (!Guid.TryParse(Console.ReadLine(), out Guid bookIdToReturn))
            {
                Console.WriteLine("Id Sách không đúng. Bạn có muốn nhập lại?");
                Console.WriteLine("1. Đồng ý");
                Console.WriteLine("2. Hủy");
                Console.Write("Lựa chọn của bạn: ");
                string retryOption = Console.ReadLine()!;

                if (retryOption == "1")
                {
                    continue;
                }
                else
                {    
                    return;
                }
            }

            Console.Write("Nhập Id Thành viên: ");
            if (!Guid.TryParse(Console.ReadLine(), out Guid memberIdToReturn))
            {
                Console.WriteLine("Id Thành viên không đúng. Bạn có muốn nhập lại?");
                Console.WriteLine("1. Đồng ý");
                Console.WriteLine("2. Hủy");
                Console.Write("Lựa chọn của bạn: ");
                string retryOption = Console.ReadLine()!;

                if (retryOption == "1")
                {
                    continue;
                }
                else
                {
                    return;
                }
            }

            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║                 Xác Nhận                   ║");
            Console.WriteLine("╠════════════════════════════════════════════╣");
            Console.WriteLine("║ 1. Lưu                                     ║");
            Console.WriteLine("║ 2. Hủy                                     ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.Write("Lựa chọn của bạn: ");
            string saveOption = Console.ReadLine()!;

            if (saveOption == "1")
            {
                _libraryService.ReturnBook(bookIdToReturn, memberIdToReturn);
                Console.WriteLine("Trả Sách thành công.");
            }
            else
            {
                Console.WriteLine("Hủy bỏ thao tác.");
            }
            return;
        }
    }

    private void ListAvailableBooks()
    {
        Console.Clear();
        var availableBooks = _libraryService.GetAvailableBooks();

        Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                            Tất cả Sách có sẵn                                    ║");
        Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════════╣");
        Console.WriteLine("║   ID                                 │ Tiêu đề              │ Tác giả            ║");
        Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════════╣");

        foreach (var b in availableBooks)
        {
            Console.WriteLine($"║ {b.Id,-36} │ {b.Title,-20} │ {b.Author,-19}║");
        }
        Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════╝");
    }

    private void ListAllMembers()
    {
        Console.Clear();
        var allMembers = _libraryService.GetAllMembers();

        Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                            Tất cả Thành viên                               ║");
        Console.WriteLine("╠════════════════════════════════════════════════════════════════════════════╣");
        Console.WriteLine("║   ID                                 │ Tên Thành viên                      ║");
        Console.WriteLine("╠════════════════════════════════════════════════════════════════════════════╣");

        foreach (var m in allMembers)
        {
            Console.WriteLine($"║ {m.Id,-36} │ {m.Name,-36}║");
        }
        Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════╝");
    }

    private void ListAllTransactions()
    {
        Console.Clear();
        var allTransactions = _libraryService.GetAllTransactions();

        Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                                                                Tất cả Giao dịch                                                                     ║");
        Console.WriteLine("╠═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
        Console.WriteLine("║   ID                                 │ ID Sách                              │ ID Thành viên                        │ Ngày mượn        │ Ngày trả    ║");
        Console.WriteLine("╠═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");

        foreach (var t in allTransactions)
        {
            Console.WriteLine($"║ {t.Id,-36} │ {t.BookId,-36} │ {t.MemberId,-32} │ {t.BorrowDate.ToShortDateString(),-16} │ {(t.ReturnDate.HasValue ? t.ReturnDate.Value.ToShortDateString() : "N/A"),-12}║");
        }
        Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
    }

    private void HandleDeleteBook()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║                Xóa Sách                    ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");

            Console.Write("Nhập Id Sách cần xóa: ");
            if (!Guid.TryParse(Console.ReadLine(), out Guid bookIdToDelete))
            {
                Console.WriteLine("Id Sách không đúng. Bạn có muốn nhập lại?");
                Console.WriteLine("1. Đồng ý");
                Console.WriteLine("2. Hủy");
                Console.Write("Lựa chọn của bạn: ");
                string retryOption = Console.ReadLine()!;

                if (retryOption == "1")
                {
                    continue;
                }
                else
                {
                    return;
                }
            }

            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║                 Xác Nhận                   ║");
            Console.WriteLine("╠════════════════════════════════════════════╣");
            Console.WriteLine("║ 1. Lưu                                     ║");
            Console.WriteLine("║ 2. Hủy                                     ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.Write("Lựa chọn của bạn: ");
            string saveOption = Console.ReadLine()!;

            if (saveOption == "1")
            {
                _libraryService.DeleteBook(bookIdToDelete);
                Console.WriteLine("Xóa Sách thành công.");
            }
            else
            {
                Console.WriteLine("Hủy bỏ thao tác.");
            }
            return;
        }
    }

    private void HandleDeleteMember()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║              Xóa Thành Viên                ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");

            Console.Write("Nhập Id Thành viên cần xóa: ");
            if (!Guid.TryParse(Console.ReadLine(), out Guid memberIdToDelete))
            {
                Console.WriteLine("Id Thành viên không đúng. Bạn có muốn nhập lại?");
                Console.WriteLine("1. Đồng ý");
                Console.WriteLine("2. Hủy");
                Console.Write("Lựa chọn của bạn: ");
                string retryOption = Console.ReadLine()!;

                if (retryOption == "1")
                {
                    continue;
                }
                else
                {
                    return;
                }
            }

            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║                 Xác Nhận                   ║");
            Console.WriteLine("╠════════════════════════════════════════════╣");
            Console.WriteLine("║ 1. Lưu                                     ║");
            Console.WriteLine("║ 2. Hủy                                     ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.Write("Lựa chọn của bạn: ");
            string saveOption = Console.ReadLine()!;

            if (saveOption == "1")
            {
                _libraryService.DeleteMember(memberIdToDelete);
                Console.WriteLine("Xóa Thành viên thành công.");
            }
            else
            {
                Console.WriteLine("Hủy bỏ thao tác.");
            }
            return;
        }
    }

    private void HandleDeleteTransaction()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║              Xóa Giao Dịch                 ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");

            Console.Write("Nhập Id Giao dịch cần xóa: ");
            if (!Guid.TryParse(Console.ReadLine(), out Guid transactionIdToDelete))
            {
                Console.WriteLine("Id Giao dịch không đúng. Bạn có muốn nhập lại?");
                Console.WriteLine("1. Đồng ý");
                Console.WriteLine("2. Hủy");
                Console.Write("Lựa chọn của bạn: ");
                string retryOption = Console.ReadLine()!;

                if (retryOption == "1")
                {
                    continue;
                }
                else
                {
                    return;
                }
            }

            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║                 Xác Nhận                   ║");
            Console.WriteLine("╠════════════════════════════════════════════╣");
            Console.WriteLine("║ 1. Lưu                                     ║");
            Console.WriteLine("║ 2. Hủy                                     ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.Write("Lựa chọn của bạn: ");
            string saveOption = Console.ReadLine()!;

            if (saveOption == "1")
            {
                _libraryService.DeleteTransaction(transactionIdToDelete);
                Console.WriteLine("Xóa Giao dịch thành công.");
            }
            else
            {
                Console.WriteLine("Hủy bỏ thao tác.");
            }
            return;
        }
    }
}
