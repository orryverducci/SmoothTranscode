#!/bin/sh

####################
### SETUP VARIABLES
####################

# Store script location
BASEDIR=$(cd "$(dirname $0)" && pwd)

# Store number of CPU cores (for make command)
OS=$(uname -s)
if [ "$OS" = "Linux" ]; then
    CPUCORES=$(nproc --all)
elif [ "$OS" = "Darwin" ]; then
    CPUCORES=$(sysctl -n hw.logicalcpu_max)
elif [ "$OS" = "FreeBSD" ]; then
    CPUCORES=$(sysctl -n hw.ncpu)
else
    CPUCORES=1
fi

# Store build flags
LDFLAGS="-L$BASEDIR/build/lib"
CFLAGS="-I$BASEDIR/build/include" 

# Store log file location
LOGFILE=$BASEDIR/build/ffmpeg-build.log

# Create output directory
cd $BASEDIR
mkdir build

######################
### BUILD FFMPEG
######################

# Output that FFmpeg is building
echo "Building FFmpeg..."

# Write heading to log file
echo "" >> $LOGFILE 2>&1
echo "BUILDING FFMPEG" >> $LOGFILE 2>&1
echo "---------------" >> $LOGFILE 2>&1

# Change to FFmpeg directory
cd $BASEDIR/ffmpeg

# Configure FFmpeg
./configure \
    --prefix=$BASEDIR/build
    --pkg-config=pkg-config \
    --pkg-config-flags=--static \
    --enable-gpl \
    --enable-version3 \
    --enable-gray \
    --disable-ffplay \
    --disable-logging \
    --disable-doc \
    --arch=x86_64 >> $LOGFILE 2>&1

# Build FFmpeg
make -j $CPUCORES >> $LOGFILE 2>&1
make install >> $LOGFILE 2>&1

# Clean FFmpeg build
make distclean >> $LOGFILE 2>&1

# Check build and exit if there was an error
if [ ! -f $BASEDIR/build/bin/ffmpeg ]; then
    echo "There was an error building FFmpeg"
    exit 1
fi
