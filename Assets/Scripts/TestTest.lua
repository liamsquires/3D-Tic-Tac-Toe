s = "globals.BoardArray[0,8] == globals.BoardArray[1,4] && globals.BoardArray[2,0] == globals.BoardArray[0,8] && globals.BoardArray[0,8] != 0)"
_,_,i,j,k,l = string.find(s, "(globals.BoardArray%b[]).-%[(.-)].-%[(.-)].-%[(.-)]")
print("Victory("..i ..","..j..","..k..","..l..");")

--print(s:match("globals.BoardArray%b[]"))