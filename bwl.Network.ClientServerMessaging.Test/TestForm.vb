Public Class TestForm
    Private _storage As New SettingsStorageRoot("testapp.ini", "TestApp")
    Private _child_1 As SettingsStorage = _storage.CreateChildStorage("Child-1", "Child 1")
    Private _child_2 As SettingsStorage = _storage.CreateChildStorage("Child-2", "Child 2")
    Private _child_1_1 As SettingsStorage = _child_1.CreateChildStorage("Child-1-1", "Child 1-1")
    Private intSetting As IntegerSetting = _storage.CreateIntegerSetting("Integer", 1, "Целое", "Описание целого")
    Private boolSetting As BooleanSetting = _storage.CreateBooleanSetting("Boolean", True, "Булево", "Описание булевого")
    Private strSetting As StringSetting = _child_1.CreateStringSetting("String", "Cat", "Строка", "Описание строки")
    Private dblSetting As DoubleSetting = _child_2.CreateDoubleSetting("Double", 1.6, "Двойное", "Описание двойного")
    Private varSetting As VariantSetting = _child_1_1.CreateVariantSetting("Variant", "Cat", {"Cat", "Dog"}, "Описание варианта")

    Private _logger As New Logger

    Private _server As New SettingsLogsServer(3165, "test", _storage, _logger)
    Private _client As New SettingsLogsClient("test")

    Private Sub TestForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        _client.NetClient.Connect("localhost", 3165)
        _client.ShowSettings(Me)
    End Sub
End Class