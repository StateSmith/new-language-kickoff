# use a *nix shell to run this script

# change to the directory of this script
cd "$(dirname "$0")"

gcc -Wall *.c -o test
./test