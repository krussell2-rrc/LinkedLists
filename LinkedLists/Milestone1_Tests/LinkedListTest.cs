using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace LinkedLists
{
    /// <summary>
    /// IMPORTANT NOTE: DO NOT CHANGE THE TEST CODE!! EVER. :)
    /// LinkedListTest - A class for testing the LinkedList class
    /// LinkedList - A class for creating and manipulating a doubly linked list of nodes containing generic data of type T.
    /// 
    /// Assignment:     #1
    /// Course:         ADEV-3009
    /// Date Created:   October 17th, 2022
    /// 
    /// @author: Scott Wachal
    /// @version 1.0
    /// </summary>
    [TestFixture]
    public class LinkedListTest
    {
        #region Milestone 1

        #region Constructor Tests, (requires .Head, .Tail, .Size, IsEmpty())
        /// <summary>
        /// Test the constructor to ensure the default values are set properly.
        /// </summary>
        [Test]
        public void new_constructor_has_size_of_zero_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(list.Size, Is.EqualTo(0));
        }

        [Test]
        /// <summary>
        /// Test GetHead returns null when a new constructor is called.
        /// </summary>
        public void GetHead_is_null_on_new_constructor_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(list.Head, Is.EqualTo(null));
        }

        [Test]
        /// <summary>
        /// Test GetTail returns null when a new constructor is called.
        /// </summary>
        public void GetTail_is_null_on_new_constructor_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(list.Tail, Is.EqualTo(null));
        }

        /// <summary>
        /// Test IsEmpty() should return true on an empty list.
        /// </summary>
        [Test]
        public void IsEmpty_is_true_on_new_constructor_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(list.IsEmpty(), Is.True);
        }

        /// <summary>
        /// Test IsEmpty() should return true on an empty list.
        /// </summary>
        [Test]
        public void IsEmpty_is_false_on_list_with_size_greater_than_0_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _); // Size == 1, Head and Tail also exist here.
            ClassicAssert.That(list.IsEmpty(), Is.False);
        }

        /// <summary>
        /// Test IsEmpty() should return true on an empty list.
        /// </summary>
        [Test]
        public void IsEmpty_is_false_on_larger_list_with_size_greater_than_0_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(10, out _); // Size == 1, Head and Tail also exist here.
            ClassicAssert.That(list.IsEmpty(), Is.False);
        }

        #endregion

        #region AddFirst(), requires: .Size / GetHead() / GetTail()
        /// <summary>
        /// Test AddFirst() to ensure node is added to list.
        /// </summary>
        [Test]
        public void AddFirst_on_emptylist_count_increases_from_0_to_1_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(list.Size, Is.EqualTo(0));
            list.AddFirst(new Employee(1));
            ClassicAssert.That(list.Size, Is.EqualTo(1));
        }

        /// <summary>
        /// Test AddFirst() method to ensure the head pointer is updated when first object is inserted.
        /// </summary>
        [Test]
        public void AddFirst_on_emptylist_Head_Updated_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(list.Head, Is.EqualTo(null));
            list.AddFirst(new Employee(1));
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
        }

        /// <summary>
        /// Test AddFirst() method to ensure the tail pointer is updated when first object is inserted.
        /// </summary>
        [Test]
        public void AddFirst_on_emptylist_Tail_Updated_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(list.Tail, Is.EqualTo(null));
            list.AddFirst(new Employee(1));
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(1)) == 0);
        }

        /// <summary>
        /// Test AddFirst() to ensure it throws and exception if element is null
        /// </summary>
        [Test]
        public void AddFirst_null_element_is_not_allowed_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(() => list.AddFirst(null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        /// <summary>
        /// Test AddFirst() method to ensure the head/tail pointers are updated when 2 elements are inserted.
        /// </summary>
        [Test]
        public void AddFirst_on_list_of_2_Head_tail_and_size_Updated_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(new Employee(2));
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Size, Is.EqualTo(1));
            list.AddFirst(new Employee(1));
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Size, Is.EqualTo(2));
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// Test AddFirst() method to ensure the head/tail pointers are updated when 3 elements are inserted.
        /// </summary>
        [Test]
        public void AddFirst_on_list_of_3_Head_tail_and_size_Updated_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddFirst(new Employee(3));
            list.AddFirst(new Employee(2));
            list.AddFirst(new Employee(1));
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(3)) == 0);
            ClassicAssert.That(list.Size, Is.EqualTo(3));
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// Test AddFirst() method to ensure the head/tail pointers are updated when 3 elements are inserted.
        /// </summary>
        [Test]
        public void AddFirst_on_large_list_Head_tail_and_size_Updated_Test()
        {
            int listSize = 10;
            LinkedList<Employee> list = new LinkedList<Employee>();
            for (int i = listSize; i >= 1; i--)
            {
                list.AddFirst(new Employee(i));
                ClassicAssert.That(list.Size, Is.EqualTo(Math.Abs(listSize-i)+1));
                ClassicAssert.That(list.Head.Element.CompareTo(new Employee(i)) == 0);
                ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(listSize)) == 0);
                ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
            }
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(listSize)) == 0);
            ClassicAssert.That(list.Size, Is.EqualTo(listSize));
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// Test AddFirst() method to ensure the head pointer is updated when many objects are inserted.
        /// </summary>
        [Test]
        public void AddFirst_on_larger_Existing_list_Head_and_size_Updated_Test()
        {
            int listSize = 5;
            Node<Employee>[] nodes;
            LinkedList<Employee> list = CreateListWithoutMethods(listSize, out nodes); // pregenerated list
            list.AddFirst(new Employee(listSize + 1)); // executes your AddFirst
            ClassicAssert.That(list.Size, Is.EqualTo(6)); // size increases
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(listSize + 1)) == 0); // head contains the new value
            ClassicAssert.That(list.Tail.Element.CompareTo(nodes[listSize - 1].Element) == 0); // tail is still the same
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list)); // all pointers are connected properly
        }
        #endregion

        #region .Size
        /// <summary>
        /// Test .Size to make sure it returns the proper size; mostly for fun here. :)
        /// </summary>
        [Test]
        public void GetSize_returns_correct_value_after_random_adds_Test()
        {
            Random rnd = new Random();
            int numberOfElements = rnd.Next(1, 50);
            LinkedList<Employee> list = new LinkedList<Employee>();
            for (int i = 0; i < numberOfElements; i++) { list.AddFirst(new Employee(i)); }
            ClassicAssert.That(list.Size, Is.EqualTo(numberOfElements));
        }
        #endregion
        
        #region GetFirst() and GetLast()

        /// <summary>
        /// Test that GetFirst throws an exception when called on an empty list, because Null.Element doesn't exist!
        /// </summary>
        [Test]
        public void GetFirst_on_emptylist_throws_exception_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(() => list.GetFirst(), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Test that GetFirst returns the head's element
        /// </summary>
        [Test]
        public void GetFirst_on_list_of_1_returns_head_element_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            ClassicAssert.That(list.Tail.Element.CompareTo(list.GetFirst()) == 0);
        }

        /// <summary>
        /// Test that GetFirst returns the head's element on LARGE list
        /// </summary>
        [Test]
        public void GetFirst_on_existing_larger_list_returns_head_element_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(10, out _);
            ClassicAssert.That(list.Head.Element.CompareTo(list.GetFirst()) == 0);
        }

        /// <summary>
        /// Test that GetLast throws an exception when called on an empty list, because Null.Element doesn't exist!
        /// </summary>
        [Test]
        public void GetLast_on_emptylist_throws_exception_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(() => list.GetLast(), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Test that GetLast returns the tail's element
        /// </summary>
        [Test]
        public void GetLast_on_list_of_1_returns_tail_element_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            ClassicAssert.That(list.Tail.Element.CompareTo(list.GetLast()) == 0);
        }

        /// <summary>
        /// Test that GetLast returns the tail's element
        /// </summary>
        [Test]
        public void GetLast_on_existing_larger_list_returns_tail_element_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(10, out _);
            ClassicAssert.That(list.Tail.Element.CompareTo(list.GetLast()) == 0);
        }
        #endregion

        #region Clear()
        /// <summary>
        /// Test that Clear() empties a list.
        /// </summary>
        [Test]
        public void ClearTest()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(5, out _);
            list.Clear();
            ClassicAssert.That(list.IsEmpty, Is.EqualTo(true));
            ClassicAssert.That(list.Size, Is.EqualTo(0));
            ClassicAssert.That(list.Head, Is.EqualTo(null));
            ClassicAssert.That(list.Tail, Is.EqualTo(null));
        }

        /// <summary>
        /// Test that calling Clear() on an empty list doesn't throw an exception.
        /// </summary>
        [Test]
        public void ClearEmptyListTest()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            try
            {
                list.Clear();
            }
            catch (Exception)
            {
                ClassicAssert.Fail("Clear() should not have thrown exception.");
            }
            ClassicAssert.Pass("Clear() did not throw exception.");
        }
        #endregion

        #region SetFirst(element)
        /// <summary>
        /// Test SetFirst() on an empty list raises an exception.
        /// </summary>
        [Test]
        public void SetFirst_on_emptyList_throws_exception_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(() => list.SetFirst(new Employee(1)), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Test SetFirst() throws exception if element null
        /// </summary>
        [Test]
        public void SetFirst_throws_exception_when_element_null_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            ClassicAssert.That(() => list.SetFirst(null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        /// <summary>
        /// Test SetFirst() replaces element on the head node on list of 1
        /// </summary>
        [Test]
        public void SetFirst_on_list_of_1_replaces_head_element_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            list.SetFirst(new Employee(2)); // changes from 1 to 2
            ClassicAssert.That(list.GetFirst().CompareTo(new Employee(2)) == 0); 
            ClassicAssert.That(list.Size,Is.EqualTo(1)); //ensure size doesn't change!
        }

        /// <summary>
        /// Test SetFirst() returns the element that has been replaced.
        /// </summary>
        [Test]
        public void SetFirst_Returns_ReplacedElement_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            var returnedData = list.SetFirst(new Employee(2));
            ClassicAssert.That(returnedData.CompareTo(new Employee(1)) == 0);
        }

        /// <summary>
        /// Test SetFirst() does_not_impact_an_existing_list (head/tail/size/pointers)
        /// </summary>
        [Test]
        public void SetFirst_does_not_impact_an_existing_larger_list_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(5, out _);
            var returnedData = list.SetFirst(new Employee(6));
            ClassicAssert.That(returnedData.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.GetFirst().CompareTo(new Employee(6)) == 0);
            ClassicAssert.That(list.Size == 5);
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        #endregion

        #region SetLast(element)
        /// <summary>
        /// Test SetLast() on an empty list raises an exception.
        /// </summary>
        [Test]
        public void SetLast_on_emptyList_throws_exception_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(() => list.SetLast(new Employee(1)), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Test SetLast() throws exception if element null
        /// </summary>
        [Test]
        public void SetLast_throws_exception_when_element_null_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            ClassicAssert.That(() => list.SetLast(null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        /// <summary>
        /// Test SetLast() replaces element on the head node on list of 1
        /// </summary>
        [Test]
        public void SetLast_on_list_of_1_replaces_head_element_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            list.SetLast(new Employee(2)); // changes from 1 to 2
            ClassicAssert.That(list.GetLast().CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Size, Is.EqualTo(1)); //ensure size doesn't change!
        }

        /// <summary>
        /// Test SetLast() returns the element that has been replaced.
        /// </summary>
        [Test]
        public void SetLast_Returns_ReplacedElement_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            var returnedData = list.SetLast(new Employee(2));
            ClassicAssert.That(returnedData.CompareTo(new Employee(1)) == 0);
        }

        /// <summary>
        /// Test SetLast() does_not_impact_an_existing_list (head/tail/size/pointers)
        /// </summary>
        [Test]
        public void SetLast_does_not_impact_an_existing_larger_list_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(5, out _);
            var returnedData = list.SetLast(new Employee(6));
            ClassicAssert.That(returnedData.CompareTo(new Employee(5)) == 0);
            ClassicAssert.That(list.GetLast().CompareTo(new Employee(6)) == 0);
            ClassicAssert.That(list.Size == 5);
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }
        #endregion
        #region AddLast()
        /// <summary>
        /// Test AddLast() to ensure node is added to list.
        /// </summary>
        [Test]
        public void AddLast_on_emptylist_count_increases_from_0_to_1_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(list.Size, Is.EqualTo(0));
            list.AddLast(new Employee(1));
            ClassicAssert.That(list.Size, Is.EqualTo(1));
        }

        /// <summary>
        /// Test AddLast() method to ensure the head pointer is updated when first object is inserted.
        /// </summary>
        [Test]
        public void AddLast_on_emptylist_Head_Updated_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(list.Head, Is.EqualTo(null));
            list.AddLast(new Employee(1));
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
        }

        /// <summary>
        /// Test AddLast() method to ensure the tail pointer is updated when first object is inserted.
        /// </summary>
        [Test]
        public void AddLast_on_emptylist_Tail_Updated_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(list.Tail, Is.EqualTo(null));
            list.AddLast(new Employee(1));
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(1)) == 0);
        }

        /// <summary>
        /// Test AddLast() to ensure it throws and exception if element is null
        /// </summary>
        [Test]
        public void AddLast_null_element_is_not_allowed_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(() => list.AddLast(null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        /// <summary>
        /// Test AddLast() method to ensure the head/tail pointers are updated when 2 elements are inserted.
        /// </summary>
        [Test]
        public void AddLast_on_list_of_2_Head_tail_and_size_Updated_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddLast(new Employee(2));
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Size, Is.EqualTo(1));
            list.AddLast(new Employee(1));
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Size, Is.EqualTo(2));
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// Test AddLast() method to ensure the head/tail pointers are updated when 3 elements are inserted.
        /// </summary>
        [Test]
        public void AddLast_on_list_of_3_Head_tail_and_size_Updated_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            list.AddLast(new Employee(3));
            list.AddLast(new Employee(2));
            list.AddLast(new Employee(1));
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(3)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Size, Is.EqualTo(3));
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// Test AddLast() method to ensure the head/tail pointers are updated when 3 elements are inserted.
        /// </summary>
        [Test]
        public void AddLast_on_large_list_Head_tail_and_size_Updated_Test()
        {
            int listSize = 10;
            LinkedList<Employee> list = new LinkedList<Employee>();
            for (int i = listSize; i >= 1; i--)
            {
                list.AddLast(new Employee(i));
                ClassicAssert.That(list.Head.Element.CompareTo(new Employee(listSize)) == 0);
                ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(i)) == 0);
                ClassicAssert.That(list.Size, Is.EqualTo(Math.Abs(listSize-i+1)));
            }

            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(listSize)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Size, Is.EqualTo(listSize));
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// Test AddLast() method to ensure the head pointer is updated when many objects are inserted.
        /// </summary>
        [Test]
        public void AddLast_on_larger_Existing_list_Head_and_size_Updated_Test()
        {
            int listSize = 5;
            Node<Employee>[] nodes;
            LinkedList<Employee> list = CreateListWithoutMethods(listSize, out nodes); // pregenerated list
            ClassicAssert.That(list.Size, Is.EqualTo(5));
            list.AddLast(new Employee(listSize + 1)); // executes your AddLast
            ClassicAssert.That(list.Size, Is.EqualTo(6)); // size increases
            ClassicAssert.That(list.Head.Element.CompareTo(nodes[0].Element) == 0); // head contains the new value
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(listSize + 1)) == 0); // tail is still the same
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list)); // all pointers are connected properly
        }
        #endregion

        #endregion

        #region Milestone 2
        #region _on()
        /// <summary>
        /// Test calling RemoveFirst() on an empty list causes an exception.
        /// </summary>
        [Test]
        public void RemoveFirst_on_EmptyList_throws_exception_test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(() => list.RemoveFirst(), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Test RemoveFirst() returns reduced count by 1
        /// </summary>
        [Test]
        public void RemoveFirst_decreases_count_by_1_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            list.RemoveFirst();
            ClassicAssert.That(list.Size, Is.EqualTo(0));
        }

        /// <summary>
        /// Test RemoveFirst() returns the element removed.
        /// </summary>
        [Test]
        public void RemoveFirst_Returns_first_Element_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            var firstElement = list.GetFirst();
            var returnedElement = list.RemoveFirst();
            ClassicAssert.That(returnedElement.CompareTo(firstElement) == 0);
        }

        /// <summary>
        /// Test RemoveFirst() removes the head and tail on size 1 list
        /// </summary>
        [Test]
        public void RemoveFirst_on_list_of_size_1_removes_head_and_tail_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            list.RemoveFirst();
            ClassicAssert.That(list.IsEmpty(), Is.EqualTo(true));
            ClassicAssert.That(list.Head, Is.EqualTo(null));
            ClassicAssert.That(list.Tail, Is.EqualTo(null));
        }

        /// <summary>
        /// RemoveFirst_on_list_2_updates_head_pointers_size_Test
        /// </summary>
        [Test]
        public void RemoveFirst_on_list_2_updates_head_pointers_size_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(2, out _);
            var returnedElement = list.RemoveFirst();
            ClassicAssert.That(list.Size, Is.EqualTo(1));
            ClassicAssert.That(returnedElement.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// RemoveFirst_on_list_3_updates_head_pointers_size_Test
        /// </summary>
        [Test]
        public void RemoveFirst_on_list_3_updates_head_pointers_size_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(3, out _);
            var returnedElement = list.RemoveFirst();
            ClassicAssert.That(list.Size, Is.EqualTo(2));
            ClassicAssert.That(returnedElement.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(3)) == 0);
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// RemoveFirst_on_larger_list_updates_head_pointers_size_Test
        /// </summary>
        [Test]
        public void RemoveFirst_on_larger_list_updates_head_pointers_size_Test()
        {
            int listSize = 10;
            LinkedList<Employee> list = CreateListWithoutMethods(listSize, out _);
            var returnedElement = list.RemoveFirst();
            ClassicAssert.That(list.Size, Is.EqualTo(listSize - 1));
            ClassicAssert.That(returnedElement.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(listSize)) == 0);
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// RemoveFirst_multiple_times_on_larger_list_updates_head_pointers_size_Test
        /// </summary>
        [Test]
        public void RemoveFirst_multiple_times_on_larger_list_updates_head_pointers_size_Test()
        {
            int listSize = 10;
            LinkedList<Employee> list = CreateListWithoutMethods(listSize, out _);
            for (int i = 1; i < listSize; i++)
            {
                var returnedElement = list.RemoveFirst();
                ClassicAssert.That(returnedElement.CompareTo(new Employee(i)) == 0);
                ClassicAssert.That(list.Size, Is.EqualTo(listSize - i));
                ClassicAssert.That(list.Head.Element.CompareTo(new Employee(i + 1)) == 0);
                ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(listSize)) == 0);
                ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
            }
            var lastReturnedElement = list.RemoveFirst();
            ClassicAssert.That(lastReturnedElement.CompareTo(new Employee(listSize)) == 0);
            ClassicAssert.That(list.IsEmpty());
            ClassicAssert.That(list.Head, Is.EqualTo(null));
            ClassicAssert.That(list.Tail, Is.EqualTo(null));
        }
        #endregion
        #region RemoveLast()
        /// <summary>
        /// Test calling RemoveLast() on an empty list causes an exception.
        /// </summary>
        [Test]
        public void RemoveLast_on_EmptyList_throws_exception_test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(() => list.RemoveLast(), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Test RemoveLast() returns reduced count by 1
        /// </summary>
        [Test]
        public void RemoveLast_decreases_count_by_1_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            list.RemoveLast();
            ClassicAssert.That(list.Size, Is.EqualTo(0));
        }

        /// <summary>
        /// Test RemoveLast() returns the element removed.
        /// </summary>
        [Test]
        public void RemoveLast_Returns_first_Element_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            var firstElement = list.GetLast();
            var returnedElement = list.RemoveLast();
            ClassicAssert.That(returnedElement.CompareTo(firstElement) == 0);
        }

        /// <summary>
        /// Test RemoveLast() removes the head and tail on size 1 list
        /// </summary>
        [Test]
        public void RemoveLast_on_list_of_size_1_removes_head_and_tail_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            list.RemoveLast();
            ClassicAssert.That(list.IsEmpty(), Is.EqualTo(true));
            ClassicAssert.That(list.Head, Is.EqualTo(null));
            ClassicAssert.That(list.Tail, Is.EqualTo(null));
        }

        /// <summary>
        /// RemoveLast_on_list_2_updates_head_pointers_size_Test
        /// </summary>
        [Test]
        public void RemoveLast_on_list_2_updates_head_pointers_size_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(2, out _);
            var returnedElement = list.RemoveLast();
            ClassicAssert.That(list.Size, Is.EqualTo(1));
            ClassicAssert.That(returnedElement.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// RemoveLast_on_list_3_updates_head_pointers_size_Test
        /// </summary>
        [Test]
        public void RemoveLast_on_list_3_updates_head_pointers_size_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(3, out _);
            var returnedElement = list.RemoveLast();
            ClassicAssert.That(list.Size, Is.EqualTo(2));
            ClassicAssert.That(returnedElement.CompareTo(new Employee(3)) == 0);
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// RemoveLast_on_larger_list_updates_head_pointers_size_Test
        /// </summary>
        [Test]
        public void RemoveLast_on_larger_list_updates_head_pointers_size_Test()
        {
            int listSize = 10;
            LinkedList<Employee> list = CreateListWithoutMethods(listSize, out _);
            var returnedElement = list.RemoveLast();
            ClassicAssert.That(list.Size, Is.EqualTo(listSize - 1));
            ClassicAssert.That(returnedElement.CompareTo(new Employee(listSize)) == 0);
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(listSize - 1)) == 0);
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// RemoveLast_multiple_times_on_larger_list_updates_head_pointers_size_Test
        /// </summary>
        [Test]
        public void RemoveLast_multiple_times_on_larger_list_updates_head_pointers_size_Test()
        {
            int listSize = 10;
            LinkedList<Employee> list = CreateListWithoutMethods(listSize, out _);
            for (int i = 10, count = 1; i > 1; i--, count++)
            {
                var returnedElement = list.RemoveLast();
                ClassicAssert.That(returnedElement.CompareTo(new Employee(i)) == 0);
                ClassicAssert.That(list.Size, Is.EqualTo(listSize - count));
                ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
                ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(listSize - count)) == 0);
                ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
            }
            var lastReturnedElement = list.RemoveLast();
            ClassicAssert.That(lastReturnedElement.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.IsEmpty());
            ClassicAssert.That(list.Head, Is.EqualTo(null));
            ClassicAssert.That(list.Tail, Is.EqualTo(null));
        }

        /// <summary>
        /// Make sure that calling Get(position) on an empty list results in an exception.
        /// </summary>
        [Test]
        public void Get_By_Position_On_EmptyList_throws_exception_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(() => list.Get(1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Make sure at calling Get(position) with a negative number results in an exception.
        /// </summary>
        [Test]
        public void Get_By_number_less_than_1_on_existingList_throws_exception_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(2, out _);
            ClassicAssert.That(() => list.Get(-1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that calling Get(positoin) with a value larger than the size of the list results in an exception.
        /// </summary>
        [Test]
        public void Get_By_Position_larger_than_list_size_throws_exception_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(2, out _);
            ClassicAssert.That(() => list.Get(list.Size + 1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that Get(position) returns the element at the correct position.
        /// </summary>
        [Test]
        public void Get_By_Position_1_on_existingList_returns_head_element_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(5, out _);
            ClassicAssert.That(list.Get(1).CompareTo(list.GetFirst()).Equals(0));
        }

        /// <summary>D
        /// Ensure that Get(position) returns the element at the correct position.
        /// </summary>
        [Test]
        public void Get_By_Position_size_on_existingList_returns_tail_element_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(5, out _);
            ClassicAssert.That(list.Get(list.Size).CompareTo(list.GetLast()).Equals(0));
        }

        /// <summary>
        /// Ensure that Get(position) returns the element at the correct position.
        /// </summary>
        [Test]
        public void Get_By_Position_3_on_existingList_returns_correct_element_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(5, out _);
            ClassicAssert.That(list.Get(3).CompareTo(list.Head.NextNode.NextNode.Element).Equals(0));
        }

        /// <summary>
        /// Ensure that Get(position) returns the element at the correct position.
        /// </summary>
        [Test]
        public void Get_By_Position_on_LARGE_existingList_returns_correct_elements_and_structure_is_not_changed_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(10, out _);
            Node<Employee> node = list.Head;
            for (int i = 1; i <= list.Size; i++)
            {
                ClassicAssert.That(list.Get(i).CompareTo(node.Element).Equals(0));
                node = node.NextNode;
            }

            // Head/Tail and all pointers are all intact and correct:
            CheckIntegrityBetweenAllNodes(list);
        }

        #region Remove(position)
        /// <summary>
        /// Make sure that calling Remove(position) on an empty list results in an exception.
        /// </summary>
        [Test]
        public void RemoveByPosition_On_EmptyList_throw_exception_Test()
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            ClassicAssert.That(() => list.Remove(1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Make sure at calling Remove(position) with a negative number results in an exception.
        /// </summary>
        [Test]
        public void RemoveByPosition_Negative_number_throws_exception_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            ClassicAssert.That(() => list.Remove(-1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that calling Remove(position) with a value of zero results in an exception.
        /// </summary>
        [Test]
        public void RemoveByPosition_Zero_throws_exception_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            ClassicAssert.That(() => list.Remove(0), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that calling Remove(position) with a value larger than the size of the list results in an exception.
        /// </summary>
        [Test]
        public void RemoveByPosition_getsize_plus_one_throws_exception_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            ClassicAssert.That(() => list.Remove(list.Size + 1), Throws.Exception.TypeOf<ApplicationException>());
        }

        /// <summary>
        /// Ensure that Remove() returns the element removed.
        /// </summary>
        [Test]
        public void RemoveByPosition_Returns_an_Element_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            var returnedElement = list.Remove(1);
            ClassicAssert.That(returnedElement.CompareTo(new Employee(1)) == 0);
        }

        /// <summary>
        /// Ensure that Remove() decreases count and clears the list
        /// </summary>
        [Test]
        public void RemoveByPosition_decreases_count_by_one_updates_head_tail_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(1, out _);
            var returnedElement = list.Remove(1);
            ClassicAssert.That(list.Size, Is.EqualTo(0));
            ClassicAssert.That(list.Head, Is.Null);
            ClassicAssert.That(list.Tail, Is.Null);
        }

        /// <summary>
        /// Ensure that Remove() list of 2 on head decreases count and updates head/tail
        /// </summary>
        [Test]
        public void RemoveByPosition_list_of_2_remove_head_updates_head_tail_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(2, out _);
            var returnedElement = list.Remove(1); // removes 1
            ClassicAssert.That(list.Size, Is.EqualTo(1));
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Tail.Equals(list.Head));
        }

        /// <summary>
        /// Ensure that Remove() list of 2 on Tail decreases count and updates head/tail
        /// </summary>
        [Test]
        public void RemoveByPosition_list_of_2_remove_tail_updates_head_tail_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(2, out _);
            var returnedElement = list.Remove(list.Size); // removes 2
            ClassicAssert.That(list.Size, Is.EqualTo(1));
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Tail.Equals(list.Head));
        }

        /// <summary>
        /// RemoveByPosition_remove_tail_on_list_of_size_3_Test
        /// </summary>
        [Test]
        public void RemoveByPosition_remove_tail_on_list_of_size_3_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(3, out _);
            var returnedElement = list.Remove(list.Size); // removes employee 3, Remaining list is: 1, 2
            ClassicAssert.That(list.Size, Is.EqualTo(2));
            ClassicAssert.That(returnedElement.CompareTo(new Employee(3)) == 0);
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// RemoveByPosition_remove_head_on_list_of_size_3_Test
        /// </summary>
        [Test]
        public void RemoveByPosition_remove_head_on_list_of_size_3_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(3, out _);
            var returnedElement = list.Remove(1); // removes employee 1, Remaining list is: 2, 3
            ClassicAssert.That(list.Size, Is.EqualTo(2));
            ClassicAssert.That(returnedElement.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(3)) == 0);
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// RemoveByPosition_remove_middle_on_list_of_size_3_Test
        /// </summary>
        [Test]
        public void RemoveByPosition_remove_middle_on_list_of_size_3_Test()
        {
            LinkedList<Employee> list = CreateListWithoutMethods(3, out _);
            var returnedElement = list.Remove(2); // removes employee 2, Remaining list is: 1, 3
            ClassicAssert.That(list.Size, Is.EqualTo(2));
            ClassicAssert.That(returnedElement.CompareTo(new Employee(2)) == 0);
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(3)) == 0);
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }

        /// <summary>
        /// RemoveByPosition_remove_middle_on_larger_list_Test
        /// </summary>
        [Test]
        public void RemoveByPosition_remove_middle_on_larger_list_Test()
        {
            int listSize = 10;
            LinkedList<Employee> list = CreateListWithoutMethods(10, out _);
            var returnedElement = list.Remove(listSize / 2); // removes employee 5, Remaining list is: 1 2 3 4 6 7 8 9 10
            ClassicAssert.That(list.Size, Is.EqualTo(listSize - 1));
            ClassicAssert.That(returnedElement.CompareTo(new Employee(listSize / 2)) == 0);
            ClassicAssert.That(list.Head.Element.CompareTo(new Employee(1)) == 0);
            ClassicAssert.That(list.Tail.Element.CompareTo(new Employee(listSize)) == 0);
            ClassicAssert.True(CheckIntegrityBetweenAllNodes(list));
        }
        #endregion
        #endregion

        /* HELPER METHODS */
        /// <summary>
        /// Ensures: 
        /// Head points previous to null
        /// Tail points next to null
        /// The head is in the first spot
        /// The tail is in the last spot
        /// Each inner node (not head/tail) is mutually pointing at it's neighbours on previous/next.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private bool CheckIntegrityBetweenAllNodes(LinkedList<Employee> list)
        {
            bool isValid = true;
            Node<Employee>[] array = ConvertToNodeArray(list);

            isValid &= array[0] == list.Head;
            isValid &= array[0].PreviousNode == null;

            isValid &= array[list.Size - 1] == list.Tail;
            isValid &= array[array.Length - 1].NextNode == null;

            for (int i = 1; i <= array.Length-2 && isValid; i++)
            {
                isValid &= CheckInnerNodeIntegrity(array[i]);
            }

            return isValid;
        }

        /// <summary>
        /// Ensures a node points previous/next to valid nodes (not null)
        /// Ensure the neighbouring nodes (before/after) also point back to the original node.
        /// </summary>
        /// <param name="node">the node to validate (must not be head/tail)</param>
        /// <returns>true if valid</returns>
        private bool CheckInnerNodeIntegrity(Node<Employee> node)
        {
            Node<Employee> before = node.PreviousNode;
            Node<Employee> after = node.NextNode;

            return before.NextNode == node && after.PreviousNode == node;
        }

        /// <summary>
        /// For testing purposes, make an array out of the LinkedList
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private Node<Employee>[] ConvertToNodeArray(LinkedList<Employee> list)
        {
            Node<Employee>[] array = new Node<Employee>[list.Size];
            int index = 0;
            int count = 0;

            for (Node<Employee> node = list.Head; node != null; node = node.NextNode, index++)
            {
                array[index] = node;
                count++;
            }

            if (count != list.Size) throw new Exception("Your LinkedList is broken. The number of nodes does not equal the size of your linkedlist");

            return array;
        }

        /// <summary>
        /// Creates a list without using any of the methods in the LinkedList class.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="nodeArray"></param>
        /// <returns></returns>
        private LinkedList<Employee> CreateListWithoutMethods(int size, out Node<Employee>[] nodeArray)
        {
            Node<Employee> beforeNode = null, node = null;

            LinkedList<Employee> list = new LinkedList<Employee>();
            nodeArray = new Node<Employee>[size];

            for (int i = 1, index = 0; i <= size; i++, index++)
            {
                node = new Node<Employee>(new Employee(i));
                nodeArray[index] = node;

                if (beforeNode != null)
                {
                    beforeNode.NextNode = node;
                    node.PreviousNode = beforeNode;
                }

                if (i == 1) list.Head = node;
                if (i == size) list.Tail = node;
                list.Size++;
                beforeNode = node;
            }

            return list;
        }
    }
    #endregion
}
