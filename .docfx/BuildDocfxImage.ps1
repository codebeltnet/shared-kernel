$version = minver -i
docfx metadata docfx.json
docker buildx build -t sharedkernel-docfx:$version --platform linux/arm64,linux/amd64 --load -f Dockerfile.docfx . # --progress plain
get-childItem -recurse -path api -include *.yml, .manifest | remove-item
