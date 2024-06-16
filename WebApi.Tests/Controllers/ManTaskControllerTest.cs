using FakeData.ManTaskData;
using FluentAssertions;
using Manager.Interfaces.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Shared.Modelviews.ManTask;
using Tasks.Controllers;

namespace WebApi.Tests.Controllers
{
    public class ManTaskControllerTest
    {
        private readonly IManTaskManager _manager;
        private readonly ManTaskController _controller;

        private readonly ManTaskView _manTaskView;
        private readonly List<ManTaskView> _listManTaskView;
        private readonly NewManTask _newManTask;
        public ManTaskControllerTest()
        {
            _manager = Substitute.For<IManTaskManager>();

            _controller = new ManTaskController(_manager);

            _manTaskView = new ManTaskViewFaker().Generate();

            _listManTaskView = new ManTaskViewFaker().Generate(10);
            _newManTask = new NewManTaskFaker().Generate();

        }

        [Fact]
        public async Task Get_Ok()
        {
            var controle = new List<ManTaskView>();
            _listManTaskView.ForEach(p => controle.Add(p.TypedClone()));
            _manager.GetAllManTasksAsync().Returns(_listManTaskView);

            var result = (ObjectResult)await _controller.Get();

            await _manager.Received().GetAllManTasksAsync();
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(controle);
        }

        [Fact]
        public async Task Get_NotFound()
        {
            _manager.GetAllManTasksAsync().Returns(new List<ManTaskView>());

            var result = (StatusCodeResult)await _controller.Get();

            await _manager.Received().GetAllManTasksAsync();
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task GetById_Ok()
        {
            _manager.GetManTaskByIdAsync(Arg.Any<int>()).Returns(_manTaskView.TypedClone());


            var result = (ObjectResult)await _controller.Get(_manTaskView.Id);

            await _manager.Received().GetManTaskByIdAsync(Arg.Any<int>());
            result.Value.Should().BeEquivalentTo(_manTaskView);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task GetById_NotFound()
        {
            _manager.GetManTaskByIdAsync(Arg.Any<int>()).Returns(new ManTaskView());
            
            var result = (StatusCodeResult)await _controller.Get(1);

            await _manager.Received().GetManTaskByIdAsync(Arg.Any<int>());
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task Post_Created()
        {
            _manager.InsertManTaskAsync(Arg.Any<NewManTask>()).Returns(_manTaskView.TypedClone());

            var result = (ObjectResult)await _controller.Post(_newManTask);

            await _manager.Received().InsertManTaskAsync(Arg.Any<NewManTask>());
            result.StatusCode.Should().Be(StatusCodes.Status201Created);
            result.Value.Should().BeEquivalentTo(_manTaskView);
        }

        [Fact]
        public async Task Put_Ok()
        {
            _manager.UpdateManTaskAsync(Arg.Any<UpdateManTask>()).Returns(_manTaskView.TypedClone());

            var result = (ObjectResult)await _controller.Put(new UpdateManTask());

            await _manager.Received().UpdateManTaskAsync(Arg.Any<UpdateManTask>());
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(_manTaskView);
        }

        [Fact]
        public async Task Put_NotFound()
        {
            _manager.UpdateManTaskAsync(Arg.Any<UpdateManTask>()).ReturnsNull();

            var result = (StatusCodeResult)await _controller.Put(new UpdateManTask());

            await _manager.Received().UpdateManTaskAsync(Arg.Any<UpdateManTask>());
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task Delete_NoContent()
        {
            _manager.DeleteManTaskAsync(Arg.Any<int>()).Returns(_manTaskView);

            var result = (StatusCodeResult)await _controller.Delete(1);

            await _manager.Received().DeleteManTaskAsync(Arg.Any<int>());
            result.StatusCode.Should().Be(StatusCodes.Status204NoContent);
        }

        [Fact]
        public async Task Delete_NotFound()
        {
            _manager.DeleteManTaskAsync(Arg.Any<int>()).ReturnsNull();

            var result = (StatusCodeResult)await _controller.Delete(1);

            await _manager.Received().DeleteManTaskAsync(Arg.Any<int>());
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }
    }
}
