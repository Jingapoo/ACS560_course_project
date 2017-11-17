#!/bin/bash

set -u

if [ "$#" != "4" ]; then
    echo 'usage {username password to_user body}'
    exit 1
fi

jsonString=$(printf '{"request":"send", "username":"%s","password":"%s", "to_user" : "%s", "body" : "%s"}' "$1" "$2" "$3" "$4")

curl -k -d "$jsonString" https://localhost:8443

echo