#ifndef __dynamitewrapper_h__
#define __dynamitewrapper_h__

#include <stdint.h>

#include "libdynamite.h"

int dynamitewrapper_explode(uint8_t *arr, size_t arr_size, uint8_t *dest, size_t dest_size);

#endif