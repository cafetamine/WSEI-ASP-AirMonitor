using System;
using AirMonitor.Core.Util.Flow;

namespace AirMonitor.Infrastructure.Flow
{
    public static class TracedOperation
    {
        #region SynchronizedInterceptors
        
        /// <summary>
        /// Overtakes synchronised operation call with intercepted logging.
        /// Accepts operation that might fail with Either Left.
        /// </summary>
        ///
        /// <param name="traceName">The name of logger used to trace operation.</param>
        /// <param name="operationType">The name of operation to be invoked.</param>
        /// <param name="command">Data used while calling operation. Only ToString is used.</param>
        /// <param name="called">Operation called and traced in this method.</param>
        ///
        /// <typeparam name="TOperationType">Type of operation called. Enum is required.</typeparam>
        /// <typeparam name="TCommand">Any type of data used while calling operation. It requires ToString.</typeparam>
        /// <typeparam name="TFailure">Call returned on Either Left when operation called failes.</typeparam>
        /// <typeparam name="TSuccess">Call returned of Either Right when operation succeeds.</typeparam>
        ///
        /// <returns>Operation result, Either success or failure.</returns>
        public static Either<TFailure, TSuccess> CallSync<TOperationType, TCommand, TFailure, TSuccess>(
                string traceName,
                TOperationType operationType,
                TCommand command,
                Func<Either<TFailure, TSuccess>> called)
            where TOperationType : Enum
            where TFailure : class
            where TSuccess : class
        {
            DateTimeOffset beginDatetime = DateTimeOffset.Now;
            // TODO log instead
            Console.WriteLine($"{beginDatetime} INFO {traceName} : {operationType} operation started at {beginDatetime} with command = {command}.");
            return called.Invoke()
                         .PeekLeft(failure =>
                         {
                             // TODO log instead
                             Console.WriteLine($"{DateTimeOffset.Now} WARN {traceName} : {operationType} operation finished after {CalculateExecTime(beginDatetime)} ms with failure = {failure}.");
                         })
                         .Peek(success =>
                         {
                             // TODO log instead
                             Console.WriteLine($"{DateTimeOffset.Now} INFO {traceName} : {operationType} operation finished after {CalculateExecTime(beginDatetime)} ms with success = {success}.");
                         });
        }

        /// <summary>
        /// Overtakes synchronised operation call with intercepted logging.
        /// Accepts operation that will always return success.
        /// An empty list or `false` value etc. is considered a success in this scenario.
        /// </summary>
        ///
        /// <param name="traceName">The name of logger used to trace operation.</param>
        /// <param name="operationType">The name of operation to be invoked.</param>
        /// <param name="command">Data used while calling operation. Only ToString is used.</param>
        /// <param name="called">Operation called and traced in this method.</param>
        ///
        /// <typeparam name="TOperationType">Type of operation called. Enum is required.</typeparam>
        /// <typeparam name="TCommand">Any type of data used while calling operation. It requires ToString.</typeparam>
        /// <typeparam name="TSuccess">Type of data returned by operation, It is always considered success.</typeparam>
        ///
        /// <returns>Operation result.</returns>
        public static TSuccess CallSync<TOperationType, TCommand, TSuccess>(
                string traceName,
                TOperationType operationType,
                TCommand command,
                Func<TSuccess> called)
            where TOperationType : Enum
        {
            DateTimeOffset beginDatetime = DateTimeOffset.Now;
            // TODO log instead
            Console.WriteLine($"{beginDatetime} INFO {traceName} : {operationType} operation started at {beginDatetime} with command = {command}.");
            TSuccess success = called.Invoke();
            // TODO log instead
            Console.WriteLine($"{DateTimeOffset.Now} INFO {traceName} : {operationType} operation finished after {CalculateExecTime(beginDatetime)} ms with success = {success}.");
            return success;
        }
        
        #endregion

        #region HelperMethods
        
        private static double CalculateExecTime(DateTimeOffset beginDatetime)
            => (DateTimeOffset.Now - beginDatetime).TotalMilliseconds;
        
        #endregion
    }
}
