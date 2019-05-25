
1HR := Object()
30M := Object()
20M := Object()
10M := Object()
05M := Object()
01M := Object()
30S := Object()
insertin := 0
Loop, read, allvidonce.txt
{
	if (A_LoopReadLine == "20M")
	{
		insertin := 1
		continue
	}
	else if (A_LoopReadLine == "10M")
	{
		insertin := 2
		continue
	}
	else if (A_LoopReadLine == "05M")
	{
		insertin := 3
		continue
	}
	else if (A_LoopReadLine == "01M")
	{
		insertin := 4
		continue
	}
	else if (A_LoopReadLine == "30S")
	{
		insertin := 5
		continue
	}
	else if (A_LoopReadLine == "1HR")
	{
		insertin := 6
		continue
	}
	else if (A_LoopReadLine == "30M")
	{
		insertin := 7
		continue
	}
	else if (A_LoopReadLine == "END")
	{
		break
	}
	
	if (insertin == 1)
	{
		20M.Insert(A_LoopReadLine)
		continue
	}
	else if (insertin == 2)
	{
		10M.Insert(A_LoopReadLine)
		continue
	}
	else if (insertin == 3)
	{
		05M.Insert(A_LoopReadLine)
		continue
	}
	else if (insertin == 4)
	{
		01M.Insert(A_LoopReadLine)
		continue
	}
	else if (insertin == 5)
	{
		30S.Insert(A_LoopReadLine)
		continue
	}
	else if (insertin == 6)
	{
		1HR.Insert(A_LoopReadLine)
		continue
	}
	else if (insertin == 7)
	{
		30M.Insert(A_LoopReadLine)
		continue
	}
}

SetTimer, timer, 600000
;;Set X (below X) to be the amount of loop iterations 
Loop, 6
{
	; -----------------------------------------------------------------------------
	; ~~~~//60 MINUTE VIDEOS//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	; -----------------------------------------------------------------------------
	test := 1HR.MaxIndex()
	counter := 0
	;Randomise(1HR)
	Loop, %test%
	{		
	
		if (counter > 5) {
			rand := 0
			Random, rand, 50000, 100000
			rand := rand + 4800000
			Sleep, %rand%
			Loop, %counter1%
			{
				Send, ^w
				Sleep, 5000
			}
			counter := 0 
		}
		
		CurrSite := 1HR[A_Index]
		Run, C:\Program Files (x86)\Google\Chrome\Application\chrome.exe %CurrSite%
		Sleep, 22000
		counter++
		counter1 := counter
	}
	
	rand := 0
	Random, rand, 50000, 100000
	rand := rand + 4800000
	Sleep, %rand%

	Loop, %counter1%
	{
		Send, ^w
		Sleep, 5000
	}
	counter1 := 0
	; -----------------------------------------------------------------------------
	; ~~~~//30 MINUTE VIDEOS//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	; -----------------------------------------------------------------------------
	test := 30M.MaxIndex()
	counter := 0
	;Randomise(30M)
	Loop, %test%
	{		
		if (counter > 5) {
			rand := 0
			Random, rand, 50000, 100000
			rand := rand + 2700000
			Sleep, %rand%
			Loop, %counter1%
			{
				Send, ^w
				Sleep, 5000
			}
			counter := 0 
		}
	
		CurrSite := 30M[A_Index]
		Run, C:\Program Files (x86)\Google\Chrome\Application\chrome.exe %CurrSite%
		Sleep, 22000
		counter++
		counter1 := counter
	}
	
	rand := 0
	Random, rand, 50000, 100000
	rand := rand + 2700000
	Sleep, %rand%
	
	Loop, %counter1%
	{
		Send, ^w
		Sleep, 5000
				
	}
	counter1 := 0
	Sleep, 60000
	
	; -----------------------------------------------------------------------------
	; ~~~~//20 MINUTE VIDEOS//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	; -----------------------------------------------------------------------------
	test := 20M.MaxIndex()
	counter := 0
	;Randomise(20M)
	Loop, %test%
	{		
	
		if (counter > 5) {
			rand := 0
			Random, rand, 50000, 100000
			rand := rand + 1380000
			Sleep, %rand%
			Loop, %counter1%
			{
				Send, ^w
				Sleep, 5000
			}
			counter := 0 
		}
		
		CurrSite := 20M[A_Index]
		Run, C:\Program Files (x86)\Google\Chrome\Application\chrome.exe %CurrSite%
		Sleep, 22000
		counter++
		counter1 := counter
	}
	
	rand := 0
	Random, rand, 50000, 100000
	rand := rand + 1380000
	Sleep, %rand%

	Loop, %counter1%
	{
		Send, ^w
		Sleep, 5000
	}
	counter1 := 0
	Sleep, 60000
	; -----------------------------------------------------------------------------
	; ~~~~//10 MINUTE VIDEOS//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	; -----------------------------------------------------------------------------
	test := 10M.MaxIndex()
	counter := 0
	;Randomise(10M)
	Loop, %test%
	{		
		if (counter > 5) {
			rand := 0
			Random, rand, 50000, 100000
			rand := rand + 960000
			Sleep, %rand%
			Loop, %counter1%
			{
				Send, ^w
				Sleep, 5000
			}
			counter := 0 
		}
	
		CurrSite := 10M[A_Index]
		Run, C:\Program Files (x86)\Google\Chrome\Application\chrome.exe %CurrSite%
		Sleep, 22000
		counter++
		counter1 := counter
	}
	
	rand := 0
	Random, rand, 50000, 100000
	rand := rand + 960000
	Sleep, %rand%
	
	Loop, %counter1%
	{
		Send, ^w
		Sleep, 5000
				
	}
	counter1 := 0
	Sleep, 60000
	; -----------------------------------------------------------------------------
	; ~~~~//5 MINUTE VIDEOS//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	; -----------------------------------------------------------------------------
	test := 05M.MaxIndex()
	counter := 0
	;Randomise(05M)
	Loop, %test%
	{		
		if (counter > 5) {
			rand := 0
			Random, rand, 5000, 20000
			rand := rand + 360000
			Sleep, %rand%
			Loop, %counter1%
			{
				Send, ^w
				Sleep, 5000
			}
			counter := 0 
		}
	
		CurrSite := 05M[A_Index]
		Run, C:\Program Files (x86)\Google\Chrome\Application\chrome.exe %CurrSite%
		Sleep, 22000
		counter++
		counter1 := counter
	}
	
	rand := 0
	Random, rand, 5000, 20000
	rand := rand + 360000
	Sleep, %rand%
	
	Loop, %counter1%
	{
		Send, ^w
		Sleep, 5000
				
	}
	counter1 := 0
	Sleep, 60000
	; -----------------------------------------------------------------------------
	; ~~~~//1 MINUTE VIDEOS//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	; -----------------------------------------------------------------------------
	test := 01M.MaxIndex()
	;counter := 0
	Randomise(01M)
	Loop, %test%
	{		
		if (counter > 5) {
			rand := 0
			Random, rand, 5000, 20000
			rand := rand + 120000
			Sleep, %rand%
			Loop, %counter1%
			{
				Send, ^w
				Sleep, 5000
			}
			counter := 0 
		}
	
		CurrSite := 01M[A_Index]
		Run, C:\Program Files (x86)\Google\Chrome\Application\chrome.exe %CurrSite%
		Sleep, 22000
		counter++
		counter1 := counter
	}
	
	rand := 0
	Random, rand, 5000, 20000
	rand := rand + 120000
	Sleep, %rand%
	
	Loop, %counter1%
	{
		Send, ^w
		Sleep, 5000
				
	}
	counter1 := 0
	Sleep, 60000
	; -----------------------------------------------------------------------------
	; ~~~~//30 SECOND VIDEOS//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	; -----------------------------------------------------------------------------
	test := 30S.MaxIndex()
	counter := 0
	;Randomise(30S)
	Loop, %test%
	{		
		if (counter > 5) {
			rand := 0
			Random, rand, 1000, 5000
			rand := rand + 40000
			Sleep, %rand%
			Loop, %counter1%
			{
				Send, ^w
				Sleep, 5000
			}
			counter := 0 
		}
	
		CurrSite := 30S[A_Index]
		Run, C:\Program Files (x86)\Google\Chrome\Application\chrome.exe %CurrSite%
		Sleep, 22000
		counter++
		counter1 := counter
	}
	
	rand := 0
	Random, rand, 1000, 5000
	rand := rand + 40000
	Sleep, %rand%
	
	Loop, %counter1%
	{
		Send, ^w
		Sleep, 5000
				
	}
	counter1 := 0
	Sleep, 60000
}
; Semi-randomises the array
Randomise(Arr) {
	amount := Arr.MaxIndex()
	amount := amount * amount
	;MsgBox, Amount is %amount%
	Loop, %amount%
	{
		Random, rand1, 0, Arr.MaxIndex()
		Random, rand2, 0, Arr.MaxIndex()
		temp1 := Arr[rand1]
		Arr.Insert(rand1, Arr[rand2])
		Arr.Insert(rand2, temp1)
	}
}

timer:
	if (A_Hour == 06) {
		Run, C:\Program Files (x86)\Google\Chrome\Application\chrome.exe www.youtube.com
		ExitApp
	}
	return
