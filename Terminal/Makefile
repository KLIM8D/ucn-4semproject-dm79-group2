.PHONY: build clean debug rebuild

CC = gcc
FILES = 
OUT_EXE = bin/Program
FLAGS = -Wall -ansi
SRC = $(addprefix src/, $(FILES))

build:	$(SRC)
	$(CC) $(FLAGS) $(SRC) -o $(OUT_EXE)

clean:
	-rm -f *.o $(OUT_EXE)

debug:
	$(CC) -g $(FLAGS) $(SRC) -o $(OUT_EXE)

rebuild: clean build
