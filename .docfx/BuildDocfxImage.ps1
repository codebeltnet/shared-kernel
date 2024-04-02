$version = minver -i
docfx metadata docfx.json
# curl -sSL --output cuemon-xrefmap.yml https://docs.cuemon.net/xrefmap.yml
# curl -sSL --output savvyio-xrefmap.yml https://docs.savvyio.net/xrefmap.yml
# (echo "baseUrl: https://docs.cuemon.net/" && cat cuemon-xrefmap.yml) > cuemon-xrefmap.lock && mv cuemon-xrefmap.lock xrefmaps/cuemon-xrefmap.yml
# (echo "baseUrl: https://docs.savvyio.net/" && cat savvyio-xrefmap.yml) > savvyio-xrefmap.lock && mv savvyio-xrefmap.lock xrefmaps/savvyio-xrefmap.yml
docker build -t sharedkernel-docfx:$version -f Dockerfile.docfx . # --progress plain
get-childItem -recurse -path api -include *.yml, .manifest | remove-item
# get-childItem -recurse -path xrefmaps -include *.yml, .manifest | remove-item
# remove-Item cuemon-xrefmap.yml
# remove-Item savvyio-xrefmap.yml