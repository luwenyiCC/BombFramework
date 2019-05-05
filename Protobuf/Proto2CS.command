#! /bin/bash

cd `dirname $0`
pwd
`dirname $0`/protoc --version
`dirname $0`/protoc -I=protos --csharp_out=protocol protos/RPC.proto protos/Game.proto
# --proto_path=`dirname $0`/proto --csharp_out=`dirname $0`/src
#cd /Users/luwenyi/Work/GitHub/Unity/OutSpace_ET/Proto
#dotnet Proto2CS.dll