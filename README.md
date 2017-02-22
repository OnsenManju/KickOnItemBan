# KickOnItemBan
Kick players on holding banned item instead of freezing

### Commands & Permissions
* **/koib** (koib.reload) - reload config file (KickOnItemBan.json)

### Configurations
```
{
  "MaxTimeLeft": 10,
  "CountDownMessage": "Take it off or you will be kicked. Time left: {0}"
}
```

##### MaxTimeLeft
Seconds until player is kicked.

##### CountDownMessage
Messages during countdown. `{0}` will be replaced by remain time.
This will be displayed after default warning message ("`You are holding a banned item: ...`").
