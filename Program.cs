namespace LibraryManagementSystem
{
    class Book
    {
        private string title;
        private string author;
        private string isbn;
        private int publicationYear;
        private int? availableCopies;
        public string Title
        {
            get { return title; }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || int.TryParse(value, out int num))
                {
                    throw new ArgumentException($"Book name Cannot be Nullable or Integer!");
                }
                else
                {
                    title = value;
                }
            }
        }
        public string Author
        {
            get { return author; }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || int.TryParse(value, out int num))
                {
                    throw new ArgumentException($"Author name Cannot be Nullable or Integer!");
                }
                else
                {
                    author = value;
                }
            }
        }
        public string ISBN
        {
            get { return isbn; }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || int.TryParse(value, out int num))
                {
                    throw new ArgumentException($"ISBN Cannot be Nullable or Integer!");
                }
                else
                {
                    isbn = value;
                }
            }
        }
        public int PublicationYear
        {
            get { return publicationYear; }
            set
            {
                if (value > DateTime.Now.Year)
                {
                    throw new ArgumentException("Invalid Publication Year Provided!");
                }
                else
                {
                    publicationYear = value;
                }
            }
        }
        public int? AvailableCopies
        {
            get { return availableCopies; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Negative value or zero is not allowed for available copies.");
                }
                availableCopies = value;
            }
        }
        //Setting Values
        public void SetBookInfo(){
            Console.Write($"Enter Your Book Name: ");
            Title = Console.ReadLine();
            Console.Write($"Enter the Author Name: ");
            Author = Console.ReadLine();
            Console.Write($"Enter the ISBN no: ");
            ISBN = Console.ReadLine();
            Console.Write($"Enter the Publication Year: ");
            PublicationYear = int.Parse(Console.ReadLine());
            Console.Write($"Enter the Book Copies: ");
            AvailableCopies = int.Parse(Console.ReadLine());
        }
        //Getting Values
        public void PrintBookInfo()
        {
            Console.WriteLine($"===========Book Information=============");
            Console.WriteLine($"Book Name: {Title}");
            Console.WriteLine($"Author Name: {Author}");
            Console.WriteLine($"ISBN Number: {ISBN}");
            Console.WriteLine($"Available Copies: {AvailableCopies}");
            Console.WriteLine($"Publication Year: {PublicationYear}");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Book b1 = new Book();
                b1.SetBookInfo();
                b1.PrintBookInfo();

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Error: {ex.ParamName}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"Error: Input is Too long or Too short!");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    }
}