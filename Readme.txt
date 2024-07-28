CS_Gas_Client_test ~ 單晶片網路連線與指令測試範例
CS_Gas_Log ~ CommandLine模式下測試程式 [基本底層模組框架類別設計]
	-Int2TwoByte(int value): 整數轉雙位元組
	-Function2Command(string strFunName,string strParam,ref int len): 函數功能名稱轉實際指令主體
	-ByteArray2HexString(byte[] byteArray,int intLen): 位元組陣列轉16禁制字串(方便顯示比對)
	-Connect(string host, int port) / Close(): TCP通訊開關
	-SendCommand(byte[] Command, int len): 將指令主體加上外殼並傳送到授控體並接收對應回應
	