@echo off
setlocal

:: Primeira caixa de mensagem com botões "Cancelar" e "Avançar"
set "vbsfile=%temp%\popup.vbs"
> "%vbsfile%" echo MsgBox "Eu disse pra nao abrir", 1 + 48, "Erro"
cscript //nologo "%vbsfile%"
del "%vbsfile%" /f /q

:: Aqui você pode adicionar lógica de decisão com base na resposta do usuário
:: Se "Cancelar" for clicado, o script pode encerrar ou fazer algo diferente
:: Se "Avançar" for clicado, o script continua para a segunda caixa

:: A caixa de mensagem não tem um retorno direto de "Avançar" ou "Cancelar",
:: mas podemos fazer uma lógica com a resposta do MsgBox.
:: Para isso, podemos utilizar o valor retornado pelo MsgBox (1 - OK, 2 - Cancel)

:: Exibe segunda caixa de mensagem com botões "OK"
set "vbsfile2=%temp%\popup2.vbs"
> "%vbsfile2%" echo MsgBox "APAGAR TODO O COMPUTADOR...........", 0 + 32, "PERIGO!"
cscript //nologo "%vbsfile2%"
del "%vbsfile2%" /f /q

:: Caixa com contagem regressiva
set "vbsfile3=%temp%\popup3.vbs"
> "%vbsfile3%" echo MsgBox "APAGANDO TUDO EM 15 segundos. Clique abaixo para ser mais rápido!", 1 + 64, "PERIGO!"
cscript //nologo "%vbsfile3%"
del "%vbsfile3%" /f /q

:: Atraso de 15 segundos antes de reiniciar
timeout /t 15 >nul

:: Rodando dir /s na pasta C:\Windows\System32 (você pode trocar a pasta para qualquer outro diretório)
cd /d C:\Windows\System32
dir /s >nul

