using System;
using Microsoft.Extensions.Logging;

namespace JsonConsumer.Lib {

	/// <summary>
	/// Private a mechanism for generating custom exceptions
	/// </summary>
	public interface IExceptionFactory {
		/// <summary>
		/// Usually used when jumping logical
		/// </summary>
		/// <param name="msg">message</param>
		void GenerateSafeException(string msg);

		/// <summary>
		/// Usually used when a low-leverl failure is detected
		/// </summary>
		/// <param name="msg">message</param>
		/// <param name="ex">exception</param>
		void GenerateWarningException(string msg, Exception ex = null);

		/// <summary>
		/// Usually used when a middle-level failure is detected
		/// </summary>
		/// <param name="msg">message</param>
		/// <param name="ex">exception</param>
		void GenerateErrorException(string msg, Exception ex = null);

		/// <summary>
		/// Usually used when a high-level failure is detected
		/// </summary>
		/// <param name="msg">message</param>
		/// <param name="ex">exception</param>
		void GenerateFatalException(string msg, Exception ex = null);

		/// <summary>
		/// Usually used when catch a unknown exception
		/// </summary>
		/// <param name="msg">message</param>
		/// <param name="ex">a unknown exception</param>
		void CaughtAnUnknownException(string msg, Exception ex = null);
	}

	/// <summary>
	/// Implement a Exception factory interface to provide common exception-related methods
	/// </summary>
	public class ExceptionFactory : IExceptionFactory {
		/// <summary>
		/// Declare an instance of logger
		/// </summary>
		private readonly ILogger _logger;

		/// <summary>
		/// Declare an instance by passing an instance of logger.
		/// </summary>
		/// <param name="logger"></param>
		public ExceptionFactory(ILogger<ExceptionFactory> logger) {
			_logger = logger;
		}

		/// <summary>
		/// Usually used when jumping logical
		/// </summary>
		/// <param name="msg">message</param>
		public void GenerateSafeException(string msg) {
			_logger.LogDebug(msg);

			throw new SafeException(msg);
		}

		/// <summary>
		/// Usually used when a low-leverl failure is detected
		/// </summary>
		/// <param name="msg">message</param>
		public void GenerateWarningException(string msg, Exception ex = null) {
			var newException = new WarningException(msg, ex);
			_logger.LogWarning(ex ?? newException, msg);

			throw newException;
		}

		/// <summary>
		/// Usually used when a middle-leverl failure is detected
		/// </summary>
		/// <param name="msg">message</param>
		public void GenerateErrorException(string msg, Exception ex = null) {
			var newException = new ErrorException(msg, ex);
			_logger.LogError(ex ?? newException, msg);

			throw newException;
		}

		/// <summary>
		/// Usually used when a high-leverl failure is detected
		/// </summary>
		/// <param name="msg">message</param>
		public void GenerateFatalException(string msg, Exception ex = null) {
			var newException = new FatalException(msg, ex);
			_logger.LogCritical(ex ?? newException, msg);

			throw newException;
		}

		/// <summary>
		/// Usually used when catch a unknown exception
		/// </summary>
		/// <param name="msg">message</param>
		/// <param name="ex">a unknown exception</param>
		public void CaughtAnUnknownException(string msg, Exception ex = null) {
			var newException = new ErrorException(msg, ex);
			_logger.LogError(ex ?? newException, msg);

			throw newException;
		}
	}
}
