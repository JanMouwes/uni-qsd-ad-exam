using NUnit.Framework;

using AD;

namespace Tests
{
    [TestFixture]
    public class SchedulerTests
    {
        [Test]
        public void Ex1b_ToStringEmpty()
        {
            Scheduler<int> scheduler = new Scheduler<int>();

            Assert.AreEqual("{High:[],Medium:[],Low:[]}", scheduler.ToString());

            scheduler.Enqueue(Priority.Low, 4);
            scheduler.Enqueue(Priority.High, 1);
            int elem = scheduler.Dequeue();

            Assert.AreEqual(1, elem);
            Assert.AreEqual("{High:[],Medium:[4],Low:[]}", scheduler.ToString());
        }

        [Test]
        public void Ex1c_Enqueue()
        {
            Scheduler<int> scheduler = new Scheduler<int>();

            scheduler.Enqueue(Priority.High, 1);
            scheduler.Enqueue(Priority.Medium, 10);
            scheduler.Enqueue(Priority.Medium, 11);
            scheduler.Enqueue(Priority.Low, 20);
            scheduler.Enqueue(Priority.Low, 21);
            scheduler.Enqueue(Priority.Low, 22);

            Assert.AreEqual("{High:[1],Medium:[10,11],Low:[20,21,22]}", scheduler.ToString());
        }
        [Test]
        public void Ex1d_DequeueExample()
        {
            Scheduler<int> scheduler = new Scheduler<int>();

            scheduler.Enqueue(Priority.Low, 4);
            scheduler.Enqueue(Priority.High, 1);
            int elem = scheduler.Dequeue();

            Assert.AreEqual(1, elem);
            Assert.AreEqual("{High:[],Medium:[4],Low:[]}", scheduler.ToString());
        }
        [Test]
        public void Ex1d_Dequeue123()
        {
            Scheduler<int> scheduler = new Scheduler<int>();

            scheduler.Enqueue(Priority.Low, 1);
            scheduler.Enqueue(Priority.Low, 2);
            scheduler.Enqueue(Priority.Low, 3);
            scheduler.Enqueue(Priority.High, 100);
            int elem = scheduler.Dequeue();
            scheduler.Enqueue(Priority.High, 101);
            elem = scheduler.Dequeue();

            Assert.AreEqual(101, elem);
            Assert.AreEqual("{High:[1],Medium:[2],Low:[3]}", scheduler.ToString());
        }
    }
}
