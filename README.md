# LC_IdentityServer4_Test

什么是OAuth2.0？：
授权机制，是一种规范/协议，指定了 授权流程解决授权问题。大家都遵守，才好沟通。
数据所有者告诉系统，同意授权第三方应用进入系统，获取这些数据。系统从而产生一个短期的进入令牌(token)，用来代替密码，供第三方应用使用。

送外卖的故事：
美团-饿了么-蜂鸟-包退小递
很多快递要进小区---小区有密码锁---能给密码吗？---不行

假设每次进来都大电话给我---确认了---放行---每次都要找我。
假设弄个临时密码，大家都一样的---有效期短点---假如我不在点饿了么---取消密码---大家都失效。
假设一人一个临时密码--临时密码找我拿的---声明自己的身份---我确认了---给你个东西(临时密码/token)---然后断时间内你就能进来---下次你还能进来

这里的token(带点信息)使用过程就是授权机制。
Token VS 密码
 a)Token短期的，密码是长期的
 b)Token可以取消，密码只能修改(影响全部)
 c)Token可以控制权限，scope
Oauth，就是Token比密码安全。

OAuth2.0四种授权：

 a)客户端凭证(Client credentials)--》授权给一个客户端，不管这个客户端有多少个用户。
 
 b)密码式(password)-》密码是客户输入给第三方，需要充分信任第三方，不安全。
 
 c)隐藏式(implicit)-》允许授权给浏览器，用户访问A--没有token--A提供跳转B登陆的地址--输入登陆B的账号密码--B授权--跳回A的地址(url带token)--访问A时带上token。-----保护了密码，暴露了token
 
 d)授权码(authorization-code)-》允许授权给浏览器，用户访问A--没有token--A提供跳转B登陆的地址--输入登陆B的账号密码--B授权--跳回A的地址(url带code)--A在后台通过code访问B获取token--访问A时带上token。-----保护密码-保护token
 
 -e)混合式(Hybrid)-》
 
 -f)自定义模式-》

IdentityServer4是基于RS256私钥公钥模式实现的。
IdentityServer4是一个中间件，ASP.NET Core 量身定制实现了OpenID Connect和OAuth2.0协议。
两种Token：
 a)JWT Token---常用
 b)Referencce Token中心化---不常用



GitHub相关说明：https://github.com/IdentityServer/IdentityServer4.Quickstart.UI


--------------------------------------------------------
OAuth2.0负责做授权，它提供的是Access_Token，确定是否有权限，但是它欠缺用户信息。
OpenID在OAuth2.0的基础上加了Id_Token，登陆之后即给Access_Token又给Id_Token。

OAuth2.0授权协议--解决了N多个快递员如何进入小区的问题Access_Token--门卫不知道快递员是谁---没有用户信息(Claims可以传，但是不关心)
OIDC(OpenID Connect)--一次请求，可以拿到两个token

OAuth---Access_Token
OIDC---Id_Token-》只能通过url地址回调，所以只能选择 隐藏式(implicit)或授权码(authorization-code)---》混合式(Hybrid)


![image](https://user-images.githubusercontent.com/26539681/116667324-a4501180-a9ce-11eb-9ae7-1a958785efdf.png)
![image](https://user-images.githubusercontent.com/26539681/116667453-cb0e4800-a9ce-11eb-8cd9-424c8e903456.png)
![image](https://user-images.githubusercontent.com/26539681/116667805-2dffdf00-a9cf-11eb-85b0-1e88f7eb31af.png)



