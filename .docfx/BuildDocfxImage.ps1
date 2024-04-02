$version = minver -i
docfx metadata docfx.json
docker build -t sharedkernel-docfx:$version -f Dockerfile.docfx . # --progress plain
get-childItem -recurse -path api -include *.yml, .manifest | remove-item
