#!/bin/bash

set -u

sourcePath="$(dirname '$0')"

cd "$sourcePath"

GOPATH="$(pwd)"
go build -o "bootchat-server" "src/bootchat-server/server.go" "src/bootchat-server/database.go"
