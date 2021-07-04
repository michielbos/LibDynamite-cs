CC=gcc

build: libdynamite.c libdynamite.h
	$(CC) -g -c libdynamite.c dynamitewrapper.c
	$(CC) -o libdynamite.so libdynamite.o dynamitewrapper.o -shared

clean:
	rm libdynamite.o dynamitewrapper.o libdynamite.so