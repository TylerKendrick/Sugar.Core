Sugar
==========

Adds sweet, simple, syntactic sugar to C#.  Reduces boilerplate code, improves readability, and increases productivity.

==========

Object Extensions:

`
var myConcern = 3;
Fluent.It(myConcern, Is.AtLeast(0));
Fluent.It(myConcern, Is.AtMost(5));
Fluent.It(myConcern, Is.AtLeast(0)).And.AtMost(5);
Fluent.It(myConcern, Is.Between(0, 5));
`
==========

Enumerable Extensions:

==========

Linq Extensions:
`
var collection = Enumerable.Repeat(0, 5);
collection.Where(Is.Between(0, 5));
`