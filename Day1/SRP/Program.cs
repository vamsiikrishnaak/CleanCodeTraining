public class PrinterDriver
{
    private IInput input;
    private IPrinter printer;

    public PrinterDriver(IInput input, IPrinter printer)
    {
        input = input;
        printer = printer;
    }

    public void Print()
    {
        buffer page = printer.GetNextPage();
        while (!input.EOP())
        {
            printer.Print(page);
            page = printer.GetNextPage();
        }
    }
}

public interface IPrinter
{
    void Print(buffer);
}

public interface IInput
{
    buffer GetNextPage();
    bool EOP();
}