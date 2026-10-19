using System;
using System.Threading;
using System.Windows.Forms;
using Cau2_QuanLyNhaTro.Services;

namespace Cau2_QuanLyNhaTro
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            LoggerService.Initialize();

            // Đăng ký bắt lỗi toàn cục (Global Exception Handling) theo mục 9.3
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Bắt lỗi trên UI Thread
            Application.ThreadException += (sender, e) =>
            {
                HandleGlobalException(e.Exception, "UI ThreadException");
            };

            // Bắt lỗi trên Non-UI Threads
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                if (e.ExceptionObject is Exception ex)
                {
                    HandleGlobalException(ex, "AppDomain UnhandledException");
                }
            };

            try
            {
                Application.Run(new FormKhachThue());
            }
            finally
            {
                LoggerService.CloseAndFlush();
            }
        }

        private static void HandleGlobalException(Exception ex, string source)
        {
            LoggerService.LogError(ex, $"[GlobalException] Đã xảy ra lỗi chưa được xử lý từ {source}: {ex.Message}");
            MessageBox.Show("Đã xảy ra lỗi, thông tin đã được ghi lại vào hệ thống log!",
                "Thông báo sự cố", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
