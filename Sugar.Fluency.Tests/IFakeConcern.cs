using System;

namespace Sugar.Fluency.Tests
{
    public interface IFakeConcern : IComparable<IFakeConcern>
    {
        int Value { get; set; }
    }
}