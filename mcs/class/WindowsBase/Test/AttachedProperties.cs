// this is a template for making NUnit version 2 tests.  Text enclosed in curly
// brackets (and the brackets themselves) should be replaced by appropriate
// code.

// DependencyObject.cs - NUnit Test Cases for attached properties
// 
// Iain McCoy (iain@mccoy.id.au)
//
// (C) iain@mccoy.id.au
// 

using NUnit.Framework;
using System;
using System.Windows;

// all test namespaces start with "MonoTests."  Append the Namespace that
// contains the class you are testing, e.g. MonoTests.System.Collections
namespace MonoTests.System.Windows
{

class X {
	public static readonly DependencyProperty AProperty = DependencyProperty.RegisterAttached("A", typeof(int), typeof(X));
	public static void SetA(DependencyObject obj, int value)
	{
		obj.SetValue(AProperty, value);
	}
	public static int GetA(DependencyObject obj)
	{
		return (int)obj.GetValue(AProperty);
	}
}

class Y : DependencyObject {
}
	
[TestFixture]
public class DependencyObjectTest : Assertion {
	
	[SetUp]
	public void GetReady() {}

	[TearDown]
	public void Clean() {}

	[Test]
	public void TestAttachedProperty()
	{
		Y y1 = new Y();
		X.SetA(y1, 2);
		AssertEquals(2, X.GetA(y1));
	}
	
	[Test]
	public void Test2AttachedProperties()
	{
		Y y1 = new Y();
		Y y2 = new Y();
		X.SetA(y1, 2);
		X.SetA(y2, 3);
		AssertEquals(2, X.GetA(y1));
		AssertEquals(3, X.GetA(y2));
	}

	// An nice way to test for exceptions the class under test should 
	// throw is:
	/*
	[Test]
	[ExpectedException(typeof(ArgumentNullException))]
	public void OnValid() {
		ConcreteCollection myCollection;
		myCollection = new ConcreteCollection();
		....
		AssertEquals ("#UniqueID", expected, actual);
		....
		Fail ("Message");
	}
	*/

}
}
