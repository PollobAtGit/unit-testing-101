﻿using AutoFixture.Xunit2;
using Explore.Model.Repository;
using FluentAssertions;
using Xunit;

namespace Explore.AutoFixture
{
    public class AutoFixtureXUnitLibShould
    {
        [Theory]
        [AutoData]
        public void Return_Autogenerated_Primitive_Value(int integer) => integer.Should().NotBe(0);

        [Theory]
        [AutoData]
        public void Return_Autogenerated_Complex_Type_Object(Repository repository) => repository.Should().NotBeNull();

        [Theory]
        [InlineAutoData(1, 2)]
        public void Return_Autogenerated_Complex_Type_Object_And_Inline_Provided_Data(int firstInteger, int secondInteger, Repository repository)
        {
            firstInteger.Should().Be(1);
            secondInteger.Should().Be(2);
            repository.Should().NotBeNull();
        }
    }
}
