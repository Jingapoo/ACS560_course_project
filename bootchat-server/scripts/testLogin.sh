#!/bin/bash

set -u

if [ "$#" != "2" ]; then
    echo 'usage {username password}'
    exit 1
fi

jsonString=$(printf '{"request":"login", "username":"%s","password":"%s"}' "$1" "$2")

curl -k -d "$jsonString" https://localhost:8443

echo