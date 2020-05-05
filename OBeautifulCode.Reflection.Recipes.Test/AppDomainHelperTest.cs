// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppDomainHelperTest.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Recipes.Test
{
    using System;

    using FakeItEasy;

    using OBeautifulCode.Assertion.Recipes;

    using Xunit;

    public static class AppDomainHelperTest
    {
        private static int actionValue = -2;

        private static int actionWithParameterValue = -3;

        private static int funcValue = -4;

        private static int funcWithParameterValue = -5;

        [Fact]
        public static void ExecuteInAppDomain_Action___Should_throw_with_specified_app_domain_name___When_action_throws_with_AppDomain_CurrentDomain_FriendlyName()
        {
            // Arrange
            Action action = ThrowOnBadAction;
            var domainName = A.Dummy<string>();
            var domain = AppDomainHelper.CreateDisposableAppDomain(domainName);

            // Act
            var actual = Record.Exception(() => action.ExecuteInAppDomain(domain));

            // Assert
            actual.AsTest().Must().BeOfType<InvalidOperationException>();
            actual.Message.AsTest().Must().BeEqualTo(domainName);

            // Cleanup
            domain.Dispose();
        }

        [Fact]
        public static void ExecuteInNewAppDomain_Action___Should_not_alter_state_of_current_app_domain___When_called()
        {
            // Arrange
            Action action = Action;

            // Act
            action.ExecuteInNewAppDomain();

            // Assert
            actionValue.AsTest().Must().BeEqualTo(-2);
        }

        [Fact]
        public static void ExecuteInAppDomain_Action_T___Should_throw_with_specified_app_domain_name_and_parameter_value___When_action_throws_with_AppDomain_CurrentDomain_FriendlyName_and_parameter_value()
        {
            // Arrange
            Action<string> action = ThrowOnBadActionWithParameter;
            var parameter = A.Dummy<string>();
            var domainName = A.Dummy<string>();
            var domain = AppDomainHelper.CreateDisposableAppDomain(domainName);

            // Act
            var actual = Record.Exception(() => action.ExecuteInAppDomain(parameter, domain));

            // Assert
            actual.AsTest().Must().BeOfType<InvalidOperationException>();
            actual.Message.AsTest().Must().BeEqualTo(parameter + domainName);

            // Cleanup
            domain.Dispose();
        }

        [Fact]
        public static void ExecuteInNewAppDomain_Action_T___Should_not_alter_state_of_current_app_domain___When_called()
        {
            // Arrange
            Action<int> action = ActionWithParameter;

            // Act
            action.ExecuteInNewAppDomain(100);

            // Assert
            actionWithParameterValue.AsTest().Must().BeEqualTo(-3);
        }

        [Fact]
        public static void ExecuteInAppDomain_Func___Should_throw_with_specified_app_domain_name___When_action_throws_with_AppDomain_CurrentDomain_FriendlyName()
        {
            // Arrange
            Func<string> func = ThrowOnBadFunc;
            var domainName = A.Dummy<string>();
            var domain = AppDomainHelper.CreateDisposableAppDomain(domainName);

            // Act
            var actual = Record.Exception(() => func.ExecuteInAppDomain(domain));

            // Assert
            actual.AsTest().Must().BeOfType<InvalidOperationException>();
            actual.Message.AsTest().Must().BeEqualTo(domainName);

            // Cleanup
            domain.Dispose();
        }

        [Fact]
        public static void ExecuteInNewAppDomain_Func___Should_not_alter_or_use_state_of_current_app_domain___When_called()
        {
            // Arrange
            Func<int> func = Func;

            // Act
            var actual = func.ExecuteInNewAppDomain();

            // Assert
            funcValue.AsTest().Must().BeEqualTo(-4);
            actual.AsTest().Must().BeEqualTo(20);
        }

        [Fact]
        public static void ExecuteInAppDomain_Func_T___Should_throw_with_specified_app_domain_name_and_parameter_value___When_func_throws_with_AppDomain_CurrentDomain_FriendlyName_and_parameter_value()
        {
            // Arrange
            Func<string, string> func = ThrowOnBadFuncWithParameter;
            var domainName = A.Dummy<string>();
            var domain = AppDomainHelper.CreateDisposableAppDomain(domainName);
            var parameter = A.Dummy<string>();

            // Act
            var actual = Record.Exception(() => func.ExecuteInAppDomain(parameter, domain));

            // Assert
            actual.AsTest().Must().BeOfType<InvalidOperationException>();
            actual.Message.AsTest().Must().BeEqualTo(parameter + domainName);

            // Cleanup
            domain.Dispose();
        }

        [Fact]
        public static void ExecuteInNewAppDomain_Func_T___Should_not_alter_or_use_state_of_current_app_domain___When_called()
        {
            // Arrange
            Func<int, int> func = FuncWithParameter;

            // Act
            var actual = func.ExecuteInNewAppDomain(40);

            // Assert
            funcWithParameterValue.AsTest().Must().BeEqualTo(-5);
            actual.AsTest().Must().BeEqualTo(40);
        }

        private static void ThrowOnBadAction()
        {
            throw new InvalidOperationException(AppDomain.CurrentDomain.FriendlyName);
        }

        private static void Action()
        {
            actionValue = 10;
        }

        private static void ThrowOnBadActionWithParameter(
            string value)
        {
            throw new InvalidOperationException(value + AppDomain.CurrentDomain.FriendlyName);
        }

        private static void ActionWithParameter(
            int value)
        {
            actionWithParameterValue = value;
        }

        private static string ThrowOnBadFunc()
        {
            throw new InvalidOperationException(AppDomain.CurrentDomain.FriendlyName);
        }

        private static int Func()
        {
            funcValue = 20;

            return funcValue;
        }

        private static string ThrowOnBadFuncWithParameter(
            string value)
        {
            throw new InvalidOperationException(value + AppDomain.CurrentDomain.FriendlyName);
        }

        private static int FuncWithParameter(
            int value)
        {
            funcWithParameterValue = value;

            return funcWithParameterValue;
        }
    }
}
