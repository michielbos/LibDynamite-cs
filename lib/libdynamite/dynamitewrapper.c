#include "dynamitewrapper.h"

#include <string.h>

/*
  Wrapper for the dynamite_explode function that reads data from an input array and writes it to a destination array.
  Returns a DynamiteResult as int.
*/
int dynamitewrapper_explode(uint8_t *arr, size_t arr_size, uint8_t *dest, size_t dest_size) {
    size_t read_progress = 0;
    size_t write_progress = 0;

    size_t array_reader(void* buffer, size_t size, void* cookie) {
        memcpy(buffer, arr + read_progress, size);
        read_progress += size;
        return size;
    }
    
    size_t array_writer(void* buffer, size_t size, void* cookie) {
        if (write_progress + size > dest_size) {
            size = dest_size - write_progress;
        }
        memcpy(dest + write_progress, buffer, size);
        write_progress += size;
        return size;
    }

    return dynamite_explode(array_reader, array_writer, NULL);
}