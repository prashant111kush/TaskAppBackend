using System;
using System.Collections.Generic;
using TaskCore.Entities;
using Xunit;

namespace UnitTests.TaskCoreTests
{
    public class CoreTaskTests
    {
        [Fact]
        public void CreateTask()
        {
            var taskId = Guid.NewGuid();
            var taskName = "testTask";
            var taskDescription = "testTaskDescription";
            var taskDate = DateTime.UtcNow;
            var taskPriority = 1;

            var coreTask = new CoreTask(taskId, taskName, taskDescription, taskDate, taskPriority);

            // Assert properties on the object
            Assert.Equal(taskId, coreTask.TaskId);
            Assert.Equal(taskName, coreTask.TaskName);
            Assert.Equal(taskDescription, coreTask.TaskDescription);
            Assert.Equal(taskDate, coreTask.TaskDateTime);
            Assert.Equal(taskPriority, coreTask.TaskPriority);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(6)]
        public void CreateTaskValidateTaskPriority(int taskPriority)
        {
            var taskId = Guid.NewGuid();
            var taskName = "testTask";
            var taskDescription = "testTaskDescription";
            var taskDate = DateTime.UtcNow;
            
            Assert.Throws<ArgumentException>(() =>
            {
                var coreTask = new CoreTask(taskId, taskName, taskDescription, taskDate, taskPriority);
            }) ;
        }

        [Fact]
        public void CreateTaskValidateTaskId()
        {
            var taskId = Guid.Empty;
            var taskName = "testTask";
            var taskDescription = "testTaskDescription";
            var taskDate = DateTime.UtcNow;
            var taskPriority = 1;

            Assert.Throws<ArgumentException>(() =>
            {
                var coreTask = new CoreTask(taskId, taskName, taskDescription, taskDate, taskPriority);
            });
        }

        [Fact]
        public void CreateTaskValidateTaskDescription()
        {
            var taskId = Guid.NewGuid();
            var taskName = "testTask";
            var taskDescription = TestHelper.RandomStringGenerator(202);
            var taskDate = DateTime.UtcNow;
            var taskPriority = 1;

            Assert.Throws<ArgumentException>(() =>
            {
                var coreTask = new CoreTask(taskId, taskName, taskDescription, taskDate, taskPriority);
            });
        }

        [Fact]
        public void CreateTaskValidateTaskDescriptionNull()
        {
            var taskId = Guid.NewGuid();
            var taskName = "testTask";
            var taskDate = DateTime.UtcNow;
            var taskPriority = 1;

            var coreTask = new CoreTask(taskId, taskName, null, taskDate, taskPriority);

            // Assert properties on the object
            Assert.Equal(taskId, coreTask.TaskId);
            Assert.Equal(taskName, coreTask.TaskName);
            Assert.Null(coreTask.TaskDescription);
            Assert.Equal(taskDate, coreTask.TaskDateTime);
            Assert.Equal(taskPriority, coreTask.TaskPriority);
        }

        [Theory]
        [MemberData(nameof(GetStringofDifferentLength))]
        public void CreateTaskValidateTaskName(string taskName)
        {
            var taskId = Guid.NewGuid();
            var taskDescription = "testTaskDescription";
            var taskDate = DateTime.UtcNow;
            var taskPriority = 1;

            Assert.Throws<ArgumentException>(() =>
            {
                var coreTask = new CoreTask(taskId, taskName, taskDescription, taskDate, taskPriority);
            });
        }

        [Fact]
        public void CreateTaskValidateTaskNameNull()
        {
            var taskId = Guid.NewGuid();
            var taskDescription = "testTaskDescription";
            var taskDate = DateTime.UtcNow;
            var taskPriority = 1;

            Assert.Throws<ArgumentNullException>(() =>
            {
                var coreTask = new CoreTask(taskId, null, taskDescription, taskDate, taskPriority);
            });
        }

        #region Private helper methods
        public static IEnumerable<object[]> GetStringofDifferentLength()
        {
            yield return new object[] { TestHelper.RandomStringGenerator(3)};
            yield return new object[] { TestHelper.RandomStringGenerator(42) };
        }
        #endregion
    }
}
