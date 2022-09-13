:: protocol协议导出cs文件

::关闭回显
@echo off

:: 获取当前bat所在路径
set batDir=%~dp0
:: 进入指定文件夹
cd /d %batDir%
:: 执行导出操作
echo batDir=%batDir%

:: protoc配置文件路径
set protocConfigPath=%batDir%%1

:: 跳转主工程路径
cd..
:: 项目中Protoc文件的存放位置
set exportPath=%cd%\Scripts\Protocol\Export

:: 删除已经存在的文件夹
if exist %exportPath% (
	del %exportPath% /f /s /q
	rd %exportPath% /s /q
)
md %exportPath%

@echo on
cd /d %batDir%
:: 参数 /R 表示需要遍历子文件夹，去掉表示不遍历子文件夹。 %%f 是一个变量，类似于迭代器，但是这个变量只能由一个字母组成,前面带上% 括号中是通配符，可以指定后缀名，*.*表示所有文件
for /R %protocConfigPath% %%f in (*.proto) do (
	protoc.exe -I=%protocConfigPath% --csharp_out=%exportPath% %%f
)

:: 复制生成的文件到项目中指定的文件夹下
:: xcopy %cs_ToolExport% %exportPath% /s/e/i/y

cmd /c "pause"