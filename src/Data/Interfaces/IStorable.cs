using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IStorable
    {
        int id {get;}
        List<string> Tags {get;}
        string Kind{get;}
    }

}