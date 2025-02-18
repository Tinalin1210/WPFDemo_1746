using System.Configuration;  //引用了 System.Configuration 命名空間（例如 App.config 或 Web.config）中的設定項。
using System.Data;           //與資料庫相關（如 Oracle、SQL Server 等）。
using System.Windows;        // WPF 應用程式的核心命名空間
using Dapper;                //執行 SQL 查詢
using Oracle.ManagedDataAccess.Client;  //用於與 Oracle 資料庫進行連接和操作
using WPFDemo_1734.Class;  //引用了你自己定義的命名空間 WPFDemo_1734.Class，可以在程式中使用 Stock 類別來表示資料庫查詢結果的結構。

namespace WPFDemo_1746
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); // 初始化視窗組件，這會載入 XAML 定義的 UI。
            LoadStockData(); // 載入資料
        }

        /// <summary>
        /// 從 Oracle 資料庫載入 Stock 資料表，並顯示在 DataGrid
        /// </summary>
        private void LoadStockData()
        {
            try
            {
                // 取得資料庫連線字串
                string connectionString = ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString;//使用 ConfigurationManager 來讀取 App.config

                using (IDbConnection db = new OracleConnection(connectionString))  //使用 OracleConnection 來創建資料庫連線
                {
                    db.Open(); // 開啟資料庫連線
                    string sql = "SELECT stock_no, stock_name, low_price, high_price, modify_date, modify_user FROM Stock";

                    // 執行 SQL 查詢並轉換為 List
                    var stockList = db.Query<Stock>(sql).ToList();

                    // 綁定 DataGrid
                    StockDataGrid.ItemsSource = stockList; // 使用 XAML 中的 StockDataGrid
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"資料載入時發生錯誤：{ex}", "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
