using System.Text;


namespace TemplateEngine;

public class TemplateEngine
{
    private string template;
    private Dictionary<string, string> variables = new Dictionary<string, string>();

    public string Evaluate()
    {
        string result = this.template;
        foreach (var pair in variables)
        {
            result = result.Replace("{" + pair.Key + "}", pair.Value);
        }

        return result;
    }

    public void SetTemplate(string value)
    {
        this.template = value;
    }

    public void SetVariable(string name, string value)
    {
        variables[name] = value;
    }
}
