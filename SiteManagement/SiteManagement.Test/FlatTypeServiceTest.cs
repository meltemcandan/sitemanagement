using AutoMapper;
using Moq;
using SiteManagement.Business.Concrete;
using SiteManagement.Business.Configuration.Mapper;
using SiteManagement.DAL.Abstract;
using SiteManagement.DTO.FlatType;
using SiteManagement.Model.Entities;
using Xunit;

namespace SiteManagement.Test
{
    public class FlatTypeServiceTest
    {
        [Fact]
        public void FlatTypeService_Add_Success()
        {
            var flatTypeRepositoryMock = new Mock<IFlatTypeRepository>();
            flatTypeRepositoryMock.Setup(x => x.Add(It.IsAny<FlatTypeEntity>()));

            MapperConfiguration mapperConfig = new MapperConfiguration(
            cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });

            IMapper mapper = new Mapper(mapperConfig);

            var flatTypeService = new FlatTypeService(flatTypeRepositoryMock.Object, mapper);

            var addFlatTypeDto = new AddFlatTypeDto()
            {
                Name = "Villa"
            };

            var response = flatTypeService.Add(addFlatTypeDto);

            Assert.True(response.Status);
        }

        [Fact]
        public void FlatTypeService_Add_Error()
        {
            var flatTypeRepositoryMock = new Mock<IFlatTypeRepository>();
            flatTypeRepositoryMock.Setup(x => x.Add(It.IsAny<FlatTypeEntity>()));

            MapperConfiguration mapperConfig = new MapperConfiguration(
            cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });

            IMapper mapper = new Mapper(mapperConfig);

            var flatTypeService = new FlatTypeService(flatTypeRepositoryMock.Object, mapper);

            var addFlatTypeDto = new AddFlatTypeDto()
            {
                Name = null
            };

            var response = flatTypeService.Add(addFlatTypeDto);

            Assert.False(response.Status);
        }

        [Fact]
        public void FlatTypeService_Update_Error()
        {
            var flatTypeRepositoryMock = new Mock<IFlatTypeRepository>();
            flatTypeRepositoryMock.Setup(x => x.Add(It.IsAny<FlatTypeEntity>()));

            MapperConfiguration mapperConfig = new MapperConfiguration(
            cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });

            IMapper mapper = new Mapper(mapperConfig);

            var flatTypeService = new FlatTypeService(flatTypeRepositoryMock.Object, mapper);

            var updateFlatTypeDto = new UpdateFlatTypeDto()
            {
                Name = null
            };

            var response = flatTypeService.Update(updateFlatTypeDto);

            Assert.False(response.Status);
        }

        [Theory]
        [InlineData(0)]
        public void FlatTypeService_Delete_Error(int id)
        {
            var flatTypeRepositoryMock = new Mock<IFlatTypeRepository>();
            flatTypeRepositoryMock.Setup(x => x.Add(It.IsAny<FlatTypeEntity>()));

            MapperConfiguration mapperConfig = new MapperConfiguration(
            cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });

            IMapper mapper = new Mapper(mapperConfig);

            var flatTypeService = new FlatTypeService(flatTypeRepositoryMock.Object, mapper);

            var response = flatTypeService.Delete(id);

            Assert.False(response.Status);
        }
    }
}
