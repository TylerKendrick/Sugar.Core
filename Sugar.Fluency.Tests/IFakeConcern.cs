using System;

namespace System.Fluency.Tests
{
    public interface IFakeConcern : IComparable<IFakeConcern>
    {
        int Value { get; set; }
    }
}