using System.Collections.Generic;

namespace RestWithAspNET5Udemy.Data.Converter.Contract
{
    public interface IParser<Input, Output>
    {
        Output Parse(Input origin);
        List<Output> Parse(List<Input> origin);
    }
}
